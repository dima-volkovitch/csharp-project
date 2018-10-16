using ProjectManagementSystem.Draft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.API.Services
{
    public interface IProjectService
    {
        IList<ProjectViewDraft> GetAllProjects();

        IList<ProjectViewDraft> GetAllWaitingProjects();

        IList<ProjectViewDraft> GetAllDuringProjects();

        IList<ProjectViewDraft> GetAllFinishedProjects();

        IList<UserViewDraft> GetUsersByProject(long ProjectId, string token);

        void CreateProject(ProjectViewDraft draft, string token);

        void AddUserToProject(long ProjectId, long UserId, string token);

        void RemoveUserFromProject(long ProjectId, long UserId, string token);
    }
}
