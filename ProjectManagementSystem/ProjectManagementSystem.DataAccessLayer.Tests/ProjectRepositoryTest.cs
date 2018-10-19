using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.DataAccessLayer.Repository;
using ProjectManagementSystem.DataAccessLayer.Repository.UnitOfWork;
using ProjectManagementSystem.Model;

namespace ProjectManagementSystem.DataAccessLayer.Tests
{
    [TestClass]
    public class ProjectRepositoryTest
    {
        private const string name = "Test Project";

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
            int firstCount = uow.Projects.GetAll().Count();
            SaveProject();
            Assert.AreEqual(firstCount + 1, uow.Projects.GetAll().Count());
        }

        [TestMethod]
        public void TestAdd()
        {
            Project p = SaveProject();
            Assert.IsNotNull(uow.Projects.Get(p.Id));
        }

        [TestMethod]
        public void TestUpdate()
        {
            Project p = SaveProject();
            p.Status = ProjectStatus.During;
            uow.Projects.Update(p);
            uow.Save();
            Assert.AreEqual(p, uow.Projects.Get(p.Id));
        }

        [TestMethod]
        public void TestDelete()
        {
            Project p = SaveProject();
            uow.Projects.Delete(p.Id);
            uow.Save();
            Assert.IsNull(uow.Projects.Get(p.Id));
        }

        private Project SaveProject()
        {
            Project p = new Project()
            {
                Name = name + (++count).ToString(),
                StartDate = DateTime.MinValue,
                FinishDate = DateTime.MaxValue,
                Status = ProjectStatus.Finished
            };
            
            uow.Projects.Add(p);
            uow.Save();
            return p;
        }
    }
}
