using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementSystem.API.Repositories;
using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.DataAccessLayer.Repository;
using ProjectManagementSystem.DataAccessLayer.Repository.UnitOfWork;
using ProjectManagementSystem.Model;

namespace ProjectManagementSystem.DataAccessLayer.Tests
{
    [TestClass]
    public class PaticipationHistoryReposicoryTest
    {
        private IUnitOfWork uow;

        [TestInitialize]
        public void Init()
        {
            uow = new UnitOfWork("UnitTestDB");
        }

        [TestMethod]
        public void IsExistActiveTest()
        {
            PaticipationHistory ph = Save();
            Assert.IsTrue(uow.PaticipationHistories.IsExistActive(ph.User.Id, ph.Project.Id));
        }

        private PaticipationHistory Save()
        {
            PaticipationHistory ph = new PaticipationHistory()
            {
                User = new User(),
                Project = new Project(),
            };
            uow.PaticipationHistories.Add(ph);
            uow.Save();
            return ph;
        }
    }
}
