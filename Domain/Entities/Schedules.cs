using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Schedules : BaseEntity
    {
        public DateTime Entry { get; set; }

        public DateTime LunchTime {get; set;}

        public DateTime ReturnLunchTime { get; set; }

        public DateTime DepartureTime { get; set; }

        public double WorkedHours { get; set; }

        public int CollaboratorId { get; set; }

        public Collaborator Collaborator { get; set; }
    }
}
