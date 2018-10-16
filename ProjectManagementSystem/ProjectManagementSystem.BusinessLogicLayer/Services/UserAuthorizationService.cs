using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.API.Services;
using ProjectManagementSystem.BusinessLogicLayer.Exceptions;
using ProjectManagementSystem.Draft;
using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Services
{
    class UserAuthorizationService : IUserAuthorizationService
    {
        private const string INVALID_LOGIN = "Invalid Login! User with this login does not exist.";
        private const string INVALID_PASSWORD = "Invalid password! User input invalid password.";

        private IUnitOfWork uow;

        public UserAuthorizationService(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        public void LogIn(UserLogInDraft draft)
        {
            User u = uow.Users.GetByLogin(draft.Login);
            if(u == null)
            {
                throw new InvalidLoginException(INVALID_LOGIN);
            }
            if (!u.Password.Equals(draft.Password))
            {
                throw new InvalidPasswordException(INVALID_PASSWORD);
            }

            string token = Cryptographer.Encode(u.Login, draft.Password);
            if (!TokenDictionary.Dictionary.ContainsToken(token))
            {
                TokenDictionary.Dictionary.Add(token, u.Id);
            }
        }

        public void LogOut(string token)
        {
            TokenDictionary.Dictionary.Remove(token);
        }
    }
    
}
