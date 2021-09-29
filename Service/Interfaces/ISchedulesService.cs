using Domain.Entities;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISchedulesService
    {
        IEnumerable<SchedulesViewModel> GetAll();

        IEnumerable<SchedulesViewModel> GetSchedulesByUserId(int id);

        SchedulesViewModel BeatTime(int idUser);
    }
}
