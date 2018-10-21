using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.API.Services;
using ProjectManagementSystem.BusinessLogicLayer.Exceptions;
using ProjectManagementSystem.Draft;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.BusinessLogicLayer.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementSystem.BusinessLogicLayer.Utils;

namespace ProjectManagementSystem.BusinessLogicLayer.Services
{
    public class UserAuthorizationService : IUserAuthorizationService
    {
        private const string invalidLogin = "Invalid Login! User with this login does not exist.";
        private const string invalidPassword = "Invalid password! User input invalid password.";
        private const string invalidToken = "Invalid jwt! Signature is not valid.";
        private const string userNotFound = "Invalid id! User with this id not found.";

        private IUnitOfWork uow;

        public UserAuthorizationService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        private User GetUser(string token)
        {
            Jwt jwt = JwtWorker.DecodeTokenString(token);
            User user = uow.Users.Get(jwt.Payload.User);
            if (user == null)
            {
                throw new UserNotFoundException(userNotFound);
            }

            if (!JwtWorker.IsValidSignature(jwt, user.Password))
            {
                throw new InvalidTokenException(invalidToken);
            }

            return user;
        }

        public string LogIn(UserLogInDraft draft)
        {
            User user = uow.Users.GetByLogin(draft.Login);
            if(user == null)
            {
                throw new InvalidLoginException(invalidLogin);
            }

            string md5Password = Cryptographer.MD5Hash(draft.Password);
            if (!user.Password.Equals(md5Password))
            {
                throw new InvalidPasswordException(invalidPassword);
            }
            
            return JwtWorker.GenerateTokenString(new Jwt(new Header(),
                new Payload() { User = user.Id }),
                user.Password); 
        }
         
        public bool IsAdmin(string token)
        {
            return GetUser(token).Role == UserRole.Admin;
        }

        public bool IsResourcesManager(string token)
        {
            return GetUser(token).Role == UserRole.ResourcesManager;
        }

        public bool IsProjectManager(string token)
        {
            return GetUser(token).Role == UserRole.ProjectManager;
        }

        public bool IsSimpleUser(string token)
        {
            return GetUser(token).Role == UserRole.Slave;
        }
    }    
}
