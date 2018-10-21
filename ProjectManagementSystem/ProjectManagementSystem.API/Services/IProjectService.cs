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
        ProjectViewDraft GetProjectById(long id);

        void CreateProject(CreateProjectDraft draft);

        void DeleteProject(long projectId);

        void FinishProject(long projectId);

        IList<UserViewDraft> GetCurrentProjectUsers(long projectId);
    }
}
