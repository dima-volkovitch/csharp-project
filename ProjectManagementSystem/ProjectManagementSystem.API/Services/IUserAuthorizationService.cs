using ProjectManagementSystem.Draft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.API.Services
{
    public interface IUserAuthorizationService
    {
        void LogIn(UserLogInDraft draft);

        void LogOut(string token);
    }
}
