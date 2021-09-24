using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class SchedulesViewModel
    {
        public DateTime Entry { get; set; }

        public DateTime LunchTime { get; set; }

        public DateTime ReturnLunchTime { get; set; }

        public DateTime DepartureTime { get; set; }

        public int ColaboratorId { get; set; }

        public Collaborator Collaborator { get; set; }

    }
}
