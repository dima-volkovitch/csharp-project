using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.DataAccessLayer.Repository;
using ProjectManagementSystem.DataAccessLayer.Repository.UnitOfWork;
using ProjectManagementSystem.Model;

namespace ProjectManagementSystem.DataAccessLayer.Tests
{
    [TestClass]
    public class UserRepositoryTest
    {
        private const string firstName = "John";
        private const string lastName = "Rodrigez";
        private const string patronymic = "Johnson";
        private const string email = "john.rodrigez@gmail.com";
        private const string phoneNumber = "8746512831";
        private const string position = "Sheep";

        private static int count;

        private IUnitOfWork uow;

        [TestInitialize]
        public void Init()
        {
            uow = new UnitOfWork("UnitTestDB");
        }

        [TestMethod]
        public void TestGetAll()
        {
            int firstCount = uow.Users.GetAll().Count();
            SaveUser();
            Assert.AreEqual(firstCount + 1, uow.Users.GetAll().Count());
        }

        [TestMethod]
        public void TestAdd()
        {
            User u = SaveUser();
            Assert.IsNotNull(uow.Users.Get(u.Id));
        }

        [TestMethod]
        public void TestUpdate()
        {
            User u = SaveUser();
            u.Role = UserRole.ProjectManager;
            uow.Users.Update(u);
            uow.Save();
            Assert.AreEqual(u, uow.Users.Get(u.Id));
        }

        [TestMethod]
        public void TestDelete()
        {
            User u = SaveUser();
            uow.Users.Delete(u.Id);
            uow.Save();
            Assert.IsNull(uow.Users.Get(u.Id));
        }

        private User SaveUser()
        {
            count++;
            User u = new User()
            {
                FirstName = firstName + count,
                LastName = lastName + count,
                Patronymic = patronymic + count,

                Login = count.ToString(),
                Password = count.ToString(),

                Email = email,
                PhoneNumber = phoneNumber,
                Position = UserPosition.FullStackDeveloper
            };
            uow.Users.Add(u);
            uow.Save();
            return u;
        }
    }
}
