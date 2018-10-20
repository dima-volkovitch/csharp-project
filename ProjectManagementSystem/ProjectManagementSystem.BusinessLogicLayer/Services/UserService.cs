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
    public class UserService : IUserService
    {
        private const string closedAccess = "Access closed! Your access level does not match the desired level.";

        private IUserAuthorizationService auth;

        private IUnitOfWork uow;

        public UserService(IUnitOfWork uow, IUserAuthorizationService auth)
        {
            this.uow = uow;
            this.auth = auth;
        }

        public void CreateUser(CreateUserDraft draft, string token)
        {
            User currentUser = auth.GetUser(token);
            if(currentUser.Role != UserRole.Admin)
            {
                throw new ClosedAccessException(closedAccess);
            }

            DraftPropertiesChecker.Check(draft);
            User user = Mapper.Map<CreateUserDraft, User>(draft);
            user.Password = Cryptographer.MD5Hash(user.Password);
            uow.Users.Add(user);
            uow.Save();
        }

        public void DeleteUser(long userId, string token)
        {
            User currentUser = auth.GetUser(token);
            if (currentUser.Role != UserRole.Admin)
            {
                throw new ClosedAccessException(closedAccess);
            }

            uow.Users.Delete(userId);
            uow.Save();
        }

        public IList<ProjectViewDraft> GetCurrentUserProjects(long userId, string token)
        {
            User currentUser = auth.GetUser(token);
            if(userId == currentUser.Id)
            {
                return Mapper.Map<IEnumerable<Project>, 
                    IList<ProjectViewDraft>>(uow.Users.GetActiveUserProjects(currentUser));
            }

            if(currentUser.Role != UserRole.ResourcesManager)
            {
                throw new ClosedAccessException(closedAccess);
            }
            return Mapper.Map<IEnumerable<Project>, IList<ProjectViewDraft>>(uow.Users.GetActiveUserProjects(userId));
        }
    }
}
