using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISchedulesRepository
    {
        IEnumerable<Schedules> GetAll();

        IEnumerable<Schedules> GetSchedulesByUserId(int id);

        Schedules CheckEntry(int id);

        double total_hours_worked(int id);

        IEnumerable<Schedules> GetAllScheduleByCollaboratorIdByMonthAndYear(int id, int year, int month);
    }
}
