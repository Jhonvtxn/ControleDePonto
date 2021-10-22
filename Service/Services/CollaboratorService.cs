﻿using AutoMapper;
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
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _CollaboratorRepository;
        private readonly IMapper _mapper;


        public CollaboratorService(ICollaboratorRepository collaboratorRepository, IMapper mapper)
        {
            _CollaboratorRepository = collaboratorRepository;
            _mapper = mapper;

        }
        public IEnumerable<CollaboratorViewModel> GetAll()
        {
            var obj = _CollaboratorRepository.GetAll();
            var objviewmodel = _mapper.Map<IEnumerable<CollaboratorViewModel>>(obj);
            return objviewmodel;

        }
        public CollaboratorViewModel GetAllAuthentication(string email, string password)
        {

            var obj = _CollaboratorRepository.GetAllAuthentication(email, password);
            var objviewmodel = _mapper.Map<CollaboratorViewModel>(obj);

            return objviewmodel;
        }

        public CollaboratorViewModel GetById(int id)
        {
            var obj = _CollaboratorRepository.GetById(id);
            var objviewmodel = _mapper.Map< CollaboratorViewModel> (obj);
            return objviewmodel;
        }
    }
}
