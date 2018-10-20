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
        void CreateProject(ProjectViewDraft draft, string token);

        void DeleteProject(long projectId, string token);

        void FinishProject(long projectId, string token);

        IList<ProjectViewDraft> GetCurrentProjectUsers(long projectId, string token);
    }
}
