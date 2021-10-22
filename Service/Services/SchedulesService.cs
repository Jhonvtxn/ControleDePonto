using AutoMapper;
using Data.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SchedulesService : ISchedulesService
    {
        private readonly ISchedulesRepository _schedulesRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Schedules> _baseRepository;
        private readonly IBaseRepository<Dashboard> _baseDashboardRepository;
        private readonly IDashboardRepository _dashboardRepository;
        
        public SchedulesService(ISchedulesRepository schedulesRepository, IMapper mapper, IBaseRepository<Schedules> baseRepository, IDashboardRepository dashboardRepository,
             IBaseRepository<Dashboard> baseDashboardRepository)
        {
            _schedulesRepository = schedulesRepository;
            _mapper = mapper;
            _baseRepository = baseRepository;
            _dashboardRepository = dashboardRepository;
            _baseDashboardRepository = baseDashboardRepository;
        }

        public SchedulesViewModel BeatTime(int idUser)
        {
            var objcheck = _schedulesRepository.CheckEntry(idUser);
            var dashboardCheck = _dashboardRepository.Get_InformationCollaborator(idUser);
            if (objcheck == null)
            {

                var objViewModel = new SchedulesViewModel() { CollaboratorId = idUser, Entry = DateTime.Now };
                var obj = _mapper.Map<Schedules>(objViewModel);
                _baseRepository.Insert(obj);

                return objViewModel;

            }
            else if (objcheck.LunchTime.Date != DateTime.Today)
            {
                objcheck.LunchTime = DateTime.Now;
                _baseRepository.Update(objcheck);
                return _mapper.Map<SchedulesViewModel>(objcheck);
            }
            else if (objcheck.ReturnLunchTime.Date != DateTime.Today)
            {
                objcheck.ReturnLunchTime = DateTime.Now;
                _baseRepository.Update(objcheck);
                return _mapper.Map<SchedulesViewModel>(objcheck);
            }
            else
            {
                objcheck.DepartureTime = DateTime.Now;
                var WorkedHour = total_hours_worked(objcheck);
                objcheck.WorkedHours = WorkedHour;
                _baseRepository.Update(objcheck);
                if (WorkedHour > 8)
                {
                    dashboardCheck.Balance = dashboardCheck.Balance + (WorkedHour - dashboardCheck.Workload);
                    _baseDashboardRepository.Update(dashboardCheck);
                }
                else if (WorkedHour < 8)
                {
                    dashboardCheck.Balance = dashboardCheck.Balance - (dashboardCheck.Workload - WorkedHour);
                    _baseDashboardRepository.Update(dashboardCheck);
                }
                return _mapper.Map<SchedulesViewModel>(objcheck);
            }
        }

        public IEnumerable<SchedulesViewModel> GetAll()
        {
            var obj = _schedulesRepository.GetAll();
            var objviewmodel = _mapper.Map<IEnumerable<SchedulesViewModel>>(obj);
            return objviewmodel;

        }
        public IEnumerable<SchedulesViewModel> GetSchedulesByUserId(int id)
        {
            var obj = _schedulesRepository.GetSchedulesByUserId(id);
            var objviewmodel = _mapper.Map<IEnumerable<SchedulesViewModel>>(obj);
            return objviewmodel;
        }

        public SchedulesViewModel GetSchedulesByUserByToday(int idUser)
        {
            var objcheck = _schedulesRepository.CheckEntry(idUser);
            if (objcheck == null)
            {

                var objViewModel = new SchedulesViewModel() { CollaboratorId = idUser, Entry = DateTime.Parse("0001-01-01T00:00:00") };


                return objViewModel;
            }
            else
            {
                return _mapper.Map<SchedulesViewModel>(objcheck);
            }
        }

        public IEnumerable<SchedulesViewModel> GetLast7Days(int idUser)
        {
            var obj = _schedulesRepository.GetSchedulesByUserId(idUser);
            var dashboarddates = obj
                .Where(Schedule => Schedule.Entry.Date <= DateTime.Now && Schedule.Entry.Date >= DateTime.Now.AddDays(-7))
                .ToList();
            var objviewmodel = _mapper.Map<IEnumerable<SchedulesViewModel>>(dashboarddates);
            return objviewmodel;
        }

        public double total_hours_worked(Schedules obj)
        {
            TimeSpan result;

            result = (obj.DepartureTime - obj.Entry) - (obj.ReturnLunchTime - obj.LunchTime);
            return result.Hours;
        }

        public double balanceHours(int idUser)
        {
            var obj = _schedulesRepository.GetSchedulesByUserId(idUser);
            var workedHours = obj
                .Where(Schedules => Schedules.WorkedHours != null)
                .ToList();
            double balance = 0;

            foreach (var hour in workedHours)
            {
                if (hour.WorkedHours > 8)
                {
                    balance = balance + (hour.WorkedHours - 8);
                }
                else
                {
                    balance = balance - (8 - hour.WorkedHours);
                }
            }
            return balance;
        }

        public IEnumerable<SchedulesViewModel> GetAllByCollaboratorIdAndYearAndMonth(int id, int year, int month)
        {
            var obj = _schedulesRepository.GetAllScheduleByCollaboratorIdByMonthAndYear(id, year, month);
            var objviewmodel = _mapper.Map<IEnumerable<SchedulesViewModel>>(obj);
            return objviewmodel;
        }
    }
}