using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dashboard : BaseEntity
    {
        public int Workload { get; set; }

        public double Balance { get; set; }

        public int CollaboratorId { get; set; }

        public Collaborator Collaborator { get; set; }
    }
}