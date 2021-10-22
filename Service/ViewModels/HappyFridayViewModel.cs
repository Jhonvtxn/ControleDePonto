using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class HappyFridayViewModel
    {
        public int CollaboratorId { get; set; }
        public CollaboratorViewModel Collaborator { get; set; }

        public int CompanyId { get; set; }
        public CompanyViewModel Company { get; set; }

        public DateTime HappyFridayDate { get; set; }
    }
}
