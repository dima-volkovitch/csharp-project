using ProjectManagementSystem.Draft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.API.Services
{
    public interface IUserService
    {
        void CreateUser(CreateUserDraft draft, string token);

        void DeleteUser(long userId, string token);

        IList<ProjectViewDraft> GetCurrentUserProjects(long userId, string token);
    }
}
