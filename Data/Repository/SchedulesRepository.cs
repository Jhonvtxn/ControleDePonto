using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SchedulesRepository : BaseRepository<Schedules>, ISchedulesRepository
    {
        public SchedulesRepository(SqlContext context) : base(context)
        {
        }
        public IEnumerable<Schedules> GetAll()
        {
            var obj = CurrentSet
                       .Include(x => x.Collaborator)
                       .ToList();

            return obj;
        }
        public IEnumerable<Schedules> GetSchedulesByUserId(int id)
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Collaborator)
                .Where(x => x.CollaboratorId == id)
                .ToList();

            return obj;
        }

        public Schedules CheckEntry(int id)
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Collaborator)
                .Where(x => x.CollaboratorId == id && (x.Entry.Date >= DateTime.Today) )
                .FirstOrDefault();

            return obj;
        }

        public double total_hours_worked(int id)
        {
            var total = new Schedules();
            total.CollaboratorId = id;
            TimeSpan result;

            result = (total.DepartureTime - total.Entry) - (total.ReturnLunchTime - total.LunchTime);
            return result.Hours;

        }

        public IEnumerable<Schedules> GetAllScheduleByCollaboratorIdByMonthAndYear(int id, int year, int month)
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Collaborator)
                .Where(x => x.Collaborator.Id == id && (x.Entry.Month == month && x.Entry.Year == year)).ToList();

            return obj;
        }
    }
}
