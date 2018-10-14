using ProjectManagementSystem.API.Repositories;
using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.DataAccessLayer.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private GeneralContext context;
        private UserRepository userRepository;
        private ProjectRepository projectRepository;

        public UnitOfWork(string connectionString)
        {
            context = new GeneralContext(connectionString);
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public IProjectRepository Projects
        {
            get
            {
                if (projectRepository == null)
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
