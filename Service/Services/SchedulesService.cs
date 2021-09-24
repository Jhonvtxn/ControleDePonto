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
    public class SchedulesService : ISchedulesService
    {
        private readonly ISchedulesRepository _schedulesRepository;
        private readonly IMapper _mapper;
        public SchedulesService(ISchedulesRepository schedulesRepository, IMapper mapper)
        {
            _schedulesRepository = schedulesRepository;
            _mapper = mapper;
        }

        public IEnumerable<SchedulesViewModel> GetAll()
        {
            var obj = _schedulesRepository.GetAll();
            var objviewmodel = _mapper.Map<IEnumerable<SchedulesViewModel>>(obj);
            return objviewmodel;

        }
    }
}
