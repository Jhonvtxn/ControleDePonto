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
    public class HappyFridayRepository : BaseRepository<HappyFriday>, IHappyFridayRepository
    {
        public HappyFridayRepository(SqlContext context) : base(context)
        {

        }

        public HappyFriday GetHappyFridayByYearAndMonthAndUserId(int idUser, int year, int month)
        {
            var obj = CurrentSet.AsNoTracking()
                .Include(x => x.Collaborator)
                .ThenInclude(x => x.Company)
                .Where(x => x.Collaborator.Id == idUser && (x.HappyFridayDate.Month == month && x.HappyFridayDate.Year == year))
                .FirstOrDefault();
            return obj;
        }

        public IEnumerable<HappyFriday> GetAll()
        {
            var obj = CurrentSet
                       .Include(x => x.Collaborator)
                       .Include(x => x.Company)
                       .ToList();

            return obj;
        }
    }
}
