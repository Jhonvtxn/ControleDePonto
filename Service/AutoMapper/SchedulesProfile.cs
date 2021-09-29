using AutoMapper;
using Domain.Entities;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapper
{
    public class SchedulesProfile : Profile
    {
        public SchedulesProfile()
            => CreateMap<Schedules, SchedulesViewModel>().ReverseMap()
            .ForMember(dto => dto.Collaborator, opt => opt.MapFrom(x => x.Collaborator));
    }
}