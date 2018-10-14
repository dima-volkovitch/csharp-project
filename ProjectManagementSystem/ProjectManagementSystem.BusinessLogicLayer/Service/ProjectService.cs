using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Service
{
    public class ProjectService : IProjectService
    {
        private IUnitOfWork uow;
        
        public ProjectService(IUnitOfWork uow)
        {
            this.uow = uow;
        }


    }
}
