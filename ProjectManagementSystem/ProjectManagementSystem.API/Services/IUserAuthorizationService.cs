using ProjectManagementSystem.Draft;
using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.API.Services
{
    public interface IUserAuthorizationService
    {
        string LogIn(UserLogInDraft draft);

        bool IsAdmin(string token);
    }
}
