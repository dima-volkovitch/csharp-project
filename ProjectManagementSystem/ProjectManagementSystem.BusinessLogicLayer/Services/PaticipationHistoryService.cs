using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.BusinessLogicLayer.Exceptions;
using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Services
{
    public class PaticipationHistoryService
    {
        private const string excpetion = "Paticipation history with this user and project exist.";
        private const string userNotFound = "User not found. User with this id does not exist.";
        private const string projectNotFound = "Project not found. Project with this id does not exist.";

        private IUnitOfWork uow;

        public PaticipationHistoryService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void CreatePaticipationHistory(long userId, long projectId)
        {
            if(!uow.PaticipationHistories.IsExistActive(userId, projectId))
            {
                throw new PaticipationHistoryException(excpetion);
            }

            User user = uow.Users.Get(userId);
            if(user == null)
            {
                throw new UserNotFoundException(userNotFound);
            }

            Project project = uow.Projects.Get(projectId);
            if(project == null)
            {
                throw new ProjectNotFoundException();
            }

            uow.PaticipationHistories.Add(new PaticipationHistory() { User = user, Project = project });
            uow.Save();
        }

        public void DisactivatePaticipationHistory(long userId, long projectId)
        {
            PaticipationHistory ph = uow.PaticipationHistories.
                GetByUserAndProjectId(userId, projectId, true).FirstOrDefault();

            if (ph == null)
            {
                throw new PaticipationHistoryException(excpetion);
            }

            ph.IsActive = false;
            ph.FinishDate = DateTime.Now;
            uow.PaticipationHistories.Update(ph);
            uow.Save();
        }
    }
}
