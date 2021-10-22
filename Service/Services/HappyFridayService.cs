using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class HappyFridayService : IHappyFridayService
    {
        private readonly IHappyFridayRepository _happyFridayRepository;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<HappyFriday> _baseRepository;
        private readonly ICollaboratorRepository _collaboratorRepository;

        public HappyFridayService(IHappyFridayRepository happyFridayRepository,
            IMapper mapper,
            IBaseRepository<HappyFriday> baseRepository,
            ICollaboratorRepository collaboratorRepository)

        {
            _happyFridayRepository = happyFridayRepository;
            _mapper = mapper;
            _baseRepository = baseRepository;
            _collaboratorRepository = collaboratorRepository;
        }

        public IEnumerable<HappyFridayViewModel> GetHappyFridayByCompanyId(int companyId, int year, int month)
        {
            var collaborators = _mapper.Map<IEnumerable<CollaboratorViewModel>>(_collaboratorRepository.GetByCompanyId(companyId));

            var happyFridaday = new List<HappyFridayViewModel>();

            foreach (var alt in collaborators)
            {
                var happy = new HappyFridayViewModel();
                happy.CollaboratorId = alt.Id;
                happy.Collaborator = alt;
                happy.CompanyId = alt.CompanyId;
                happy.HappyFridayDate = DateHappyFriday(alt.Id, year, month);
                happyFridaday.Add(happy);
            }
            return happyFridaday;
        }
        public HappyFridayViewModel Create(HappyFridayViewModel obj)
        {
            var collaboratorHappy = _happyFridayRepository.GetHappyFridayByYearAndMonthAndUserId(obj.CollaboratorId, obj.HappyFridayDate.Year, obj.HappyFridayDate.Month);
            if (collaboratorHappy != null)
            {
                return new HappyFridayViewModel();
            }
            else
            {
                var collaboratordayoff = _mapper.Map<HappyFriday>(obj);
                _baseRepository.Insert(collaboratordayoff);
                return obj;
            }
        }

        public DateTime DateHappyFriday(int idUser, int year, int month)
        {
            var collaboratorHappy = _happyFridayRepository.GetHappyFridayByYearAndMonthAndUserId(idUser, year, month);
            if (collaboratorHappy != null)
            {
                return collaboratorHappy.HappyFridayDate;
            }
            else
            {
                return new DateTime();
            }
        }

        public IEnumerable<HappyFridayViewModel> GetAll()
        {
            var obj = _happyFridayRepository.GetAll();
            var objviewmodel = _mapper.Map<IEnumerable<HappyFridayViewModel>>(obj);
            return objviewmodel;
        }
    }
}
