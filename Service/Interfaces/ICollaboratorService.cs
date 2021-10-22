using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{ 
    public interface ICollaboratorService
    {
        IEnumerable<CollaboratorViewModel> GetAll();

        CollaboratorViewModel GetAllAuthentication(string emailAut, string PasswordAut);

        CollaboratorViewModel GetById(int id);
    }
}
