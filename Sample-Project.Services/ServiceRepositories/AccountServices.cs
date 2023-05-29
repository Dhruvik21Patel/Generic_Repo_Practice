using AutoMapper;
using Sample_Project.entities.Auth;
using Sample_Project.entities.Models;
using Sample_Project.entities.ViewModels;
using Sample_Project.Repository.Interface;
using Sample_Project.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Services.ServiceRepositories
{
    public class AccountServices : GenericService<User>, IAccountServices
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountServices(IAccountRepository accountRepository, IMapper mapper) : base (accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public SessionDetailsViewModel getUserRoleAndSetToSession(User user)
        {
            SessionDetailsViewModel sessionDetailsViewModel = _mapper.Map<SessionDetailsViewModel>(user);
            return sessionDetailsViewModel;
        }

        public User validateLogin(LoginViewModel model)
        {
            return _accountRepository.FindBy(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
        }
    }
}
