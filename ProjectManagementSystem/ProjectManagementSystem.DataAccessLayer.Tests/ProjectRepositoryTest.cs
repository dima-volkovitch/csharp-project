using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagementSystem.DataAccessLayer.Repository;
using ProjectManagementSystem.Model;

namespace ProjectManagementSystem.DataAccessLayer.Tests
{
    [TestClass]
    public class ProjectRepositoryTest
    {
        private static int count;

        private UnitOfWork uow = new UnitOfWork("UnitTestDB");

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
            p.Status = ProjectStatus.DURING;
            uow.Projects.Update(p);
            uow.Save();
            Assert.AreEqual(p, uow.Projects.Get(p.Id));
        }

        [TestMethod]
        public void TestDelete()
        {
            Project p = SaveProject();
            uow.Projects.Delete(p);
            uow.Save();
            Assert.IsNull(uow.Projects.Get(p.Id));
        }

        private Project SaveProject()
        {
            Project p = new Project()
            {
                Name = "Method Test Get All" + (++count).ToString(),
                StartDate = DateTime.MinValue,
                FinishDate = DateTime.MaxValue,
                Status = ProjectStatus.FINISHED
            };

            Business b = new Business()
            {
                Project = p,
                User = new User
                {
                    FirstName = "Kochka",
                    LastName = "Kachok",
                    Patronymic = "QWEWDS"
                },
                EmploymentPercentage = 120.0

            };

            p.Businesses = new List<Business>() { b };

            uow.Projects.Add(p);
            uow.Save();
            return p;
        }
    }
}
