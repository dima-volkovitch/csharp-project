using ProjectManagementSystem.API.Repository;
using ProjectManagementSystem.DataAccessLayer.Context;
using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.DataAccessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private PMSContext context;
        private UserRepository userRepository;
        private ProjectRepository projectRepository;

        public UnitOfWork(string connectionString)
        {
            context = new PMSContext(connectionString);
        }

        public IRepository<User> Users {
            get
            {
                if(userRepository == null)
                {
                    userRepository = new UserRepository(context);   
                }
                return userRepository;
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                if(projectRepository == null)
                {
                    projectRepository = new ProjectRepository(context);
                }
                return projectRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
