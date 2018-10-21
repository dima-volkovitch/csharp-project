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
        void CreateUser(CreateUserDraft draft);

        void DeleteUser(long userId);

        IList<ProjectViewDraft> GetCurrentUserProjects(long userId);
    }
}
