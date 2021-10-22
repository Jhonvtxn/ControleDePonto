using AutoMapper;
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
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _DashboardRepository;
        private readonly ISchedulesRepository _schedulesRepository;
        private readonly ISchedulesService _schedulesService;
        private readonly IMapper _mapper;


        public DashboardService(IDashboardRepository dashboardRepository, ISchedulesRepository schedulesRepository,ISchedulesService schedulesService,IMapper mapper)
        {
            _DashboardRepository = dashboardRepository;
            _schedulesRepository = schedulesRepository;
            _schedulesService = schedulesService;
            _mapper = mapper;
        }
        public IEnumerable<DashboardViewModel> GetAll()
        {
            var obj = _DashboardRepository.GetAll();
            var objviewmodel = _mapper.Map<IEnumerable<DashboardViewModel>>(obj);
            return objviewmodel;
        }

        public DashboardViewModel Get_InformationCollaborator(int idUser)
        {
            var obj = _DashboardRepository.Get_InformationCollaborator(idUser);
            var objView = _mapper.Map<DashboardViewModel>(obj);
            var Last7DaysCollaborator = _schedulesService.GetLast7Days(idUser);
            objView.Lasthours7Days = Last7DaysCollaborator;
            return objView;
        }
    }
}
