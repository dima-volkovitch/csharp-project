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
        private IUnitOfWork uow;

        public UserService(IUnitOfWork uow, IUserAuthorizationService auth)
        {
            this.uow = uow;
        }

        public void CreateUser(CreateUserDraft draft)
        {
            DraftPropertiesChecker.Check(draft);
            User user = Mapper.Map<CreateUserDraft, User>(draft);
            user.Password = Cryptographer.MD5Hash(user.Password);
            uow.Users.Add(user);
            uow.Save();
        }

        public void DeleteUser(long userId)
        {
            uow.Users.Delete(userId);
            uow.Save();
        }

        public IList<ProjectViewDraft> GetCurrentUserProjects(long userId)
        {
            return Mapper.Map<IEnumerable<Project>, IList<ProjectViewDraft>>(uow.Users.GetActiveUserProjects(userId));
        }
    }
}
