using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.API.Services;
using ProjectManagementSystem.BusinessLogicLayer.Services;
using ProjectManagementSystem.BusinessLogicLayer.Token;
using ProjectManagementSystem.BusinessLogicLayer.Utils;
using ProjectManagementSystem.DataAccessLayer.Repository.UnitOfWork;
using ProjectManagementSystem.Draft;
using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Tests
{
    [TestClass]
    public class UserAuthorizationServiceTest
    {
        private const string firstName = "John";
        private const string lastName = "Rodrigez";
        private const string patronymic = "Johnson";
        private const string email = "john.rodrigez@gmail.com";
        private const string phoneNumber = "8746512831";
        private const string position = "Sheep";
        private const string login = "vika";
        private const string password = "123";
        
        private IUserAuthorizationService auth;
        private IUnitOfWork uow;

        [TestInitialize]
        public void Init()
        {
            uow = new UnitOfWork("UnitTestDB");
            auth = new UserAuthorizationService(uow);
        }

        [TestMethod]
        public void LogInTest()
        {
            User user = CreateUser();
            UserLogInDraft draft = new UserLogInDraft()
            {
                Login = user.Login,
                Password = user.Id.ToString()
            };
            string oldToken = auth.LogIn(draft);
            string newToken = JwtWorker.GenerateTokenString(new Jwt(new Header(),
                new Payload() { User = user.Id }), user.Password);
            Assert.AreNotEqual(oldToken, newToken);
        }

        private User CreateUser()
        {
            User u = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Patronymic = patronymic,
                
                Email = email,
                PhoneNumber = phoneNumber,
                Position = UserPosition.FullStackDeveloper
            };
            uow.Users.Add(u);
            uow.Save();

            u.Login = u.Id + u.LastName;
            u.Password = Cryptographer.MD5Hash(u.Id.ToString());
            uow.Users.Update(u);
            uow.Save();
            return u;
        }
    }
}
