using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IHappyFridayService
    {
        IEnumerable<HappyFridayViewModel> GetHappyFridayByCompanyId(int companyId, int year, int month);
        HappyFridayViewModel Create(HappyFridayViewModel obj);
        IEnumerable<HappyFridayViewModel> GetAll();

    }
}
