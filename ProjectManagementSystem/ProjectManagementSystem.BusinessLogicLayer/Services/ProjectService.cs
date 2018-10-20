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
        private const string closedAccess = "Access closed! Your access level does not match the desired level.";

        private IUserAuthorizationService auth;

        private IUnitOfWork uow;

        public ProjectService(IUnitOfWork uow, IUserAuthorizationService auth)
        {
            this.uow = uow;
            this.auth = auth;
        }

        public void CreateProject(ProjectViewDraft draft, string token)
        {
            User currentUser = auth.GetUser(token);
            if(currentUser.Role != UserRole.ResourcesManager)
            {
                throw new ClosedAccessException(closedAccess);
            }

            DraftPropertiesChecker.Check(draft);
            uow.Projects.Add(Mapper.Map<ProjectViewDraft, Project>(draft));
            uow.Save();
        }

        public void DeleteProject(long projectId, string token)
        {
            User currentUser = auth.GetUser(token);
            if (currentUser.Role != UserRole.ResourcesManager)
            {
                throw new ClosedAccessException(closedAccess);
            }

            uow.Projects.Delete(projectId);
            uow.Save();
        }

        public void FinishProject(long projectId, string token)
        {
            User currentUser = auth.GetUser(token);
            if (currentUser.Role != UserRole.ResourcesManager)
            {
                throw new ClosedAccessException(closedAccess);
            }

            Project project = uow.Projects.Get(projectId);
            project.Status = ProjectStatus.Finished;
            project.FinishDate = DateTime.Now;
            uow.Projects.Update(project);
            uow.Save();
        }

        public IList<UserViewDraft> GetCurrentProjectUsers(long projectId, string token)
        {
            User currentUser = auth.GetUser(token);
            if(uow.Projects.IsUserPaticipateInProject(projectId, currentUser) 
                || currentUser.Role == UserRole.ResourcesManager)
            {
                return Mapper.Map<IEnumerable<User>, IList<UserViewDraft>>(uow.Projects.GetActiveProjectUsers(projectId));
            }

            throw new ClosedAccessException(closedAccess);
        }
    }
}
