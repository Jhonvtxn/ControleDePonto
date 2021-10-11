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
        private readonly IMapper _mapper;
        private readonly ISchedulesRepository _schedulesRepository;

        public DashboardService(IDashboardRepository dashboardRepository, IMapper mapper)
        {
            _DashboardRepository = dashboardRepository;
            _mapper = mapper;
        }
        public IEnumerable<DashboardViewModel> GetAll()
        {
            var obj = _DashboardRepository.GetAll();
            var objviewmodel = _mapper.Map<IEnumerable<DashboardViewModel>>(obj);
            return objviewmodel;
        }
    }
}
