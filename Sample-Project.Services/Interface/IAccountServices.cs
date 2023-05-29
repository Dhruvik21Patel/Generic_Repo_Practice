using Sample_Project.entities.Auth;
using Sample_Project.entities.Models;
using Sample_Project.entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Project.Services.Interface
{
    public interface IAccountServices
    {
        SessionDetailsViewModel getUserRoleAndSetToSession(User user);
        User validateLogin(LoginViewModel model);
    }
}
