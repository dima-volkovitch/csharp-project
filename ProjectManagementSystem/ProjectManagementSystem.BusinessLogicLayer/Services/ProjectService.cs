using AutoMapper;
using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.API.Services;
using ProjectManagementSystem.BusinessLogicLayer.Exceptions;
using ProjectManagementSystem.BusinessLogicLayer.Utils;
using ProjectManagementSystem.Draft;
using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Services
{
    public class ProjectService : IProjectService
    {
        private IUnitOfWork uow;

        public ProjectService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public ProjectViewDraft GetProjectById(long id)
        {
            return Mapper.Map<Project, ProjectViewDraft>(uow.Projects.Get(id));
        }

        public void CreateProject(CreateProjectDraft draft)
        {
            DraftPropertiesChecker.Check(draft);
            uow.Projects.Add(Mapper.Map<CreateProjectDraft, Project>(draft));
            uow.Save();
        }

        public void DeleteProject(long projectId)
        {
            uow.Projects.Delete(projectId);
            uow.Save();
        }

        public void FinishProject(long projectId)
        {
            Project project = uow.Projects.Get(projectId);
            project.Status = ProjectStatus.Finished;
            project.FinishDate = DateTime.Now;
            uow.Projects.Update(project);
            uow.Save();
        }

        public IList<UserViewDraft> GetCurrentProjectUsers(long projectId)
        {
            return Mapper.Map<IEnumerable<User>, 
                IList<UserViewDraft>>(uow.Projects.GetActiveProjectUsers(projectId));
        }
    }
}
