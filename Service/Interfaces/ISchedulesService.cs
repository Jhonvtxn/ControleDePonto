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

        SchedulesViewModel GetSchedulesByUserByToday(int idUser);

        SchedulesViewModel BeatTime(int idUser);

        IEnumerable<SchedulesViewModel> GetLast7Days(int idUser);

        double balanceHours(int idUser);

        IEnumerable<SchedulesViewModel> GetAllByCollaboratorIdAndYearAndMonth(int id, int year, int month);
    }
}
