using ProjectManagementSystem.API.Repositories;
using ProjectManagementSystem.DataAccessLayer.Context;
using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.DataAccessLayer.Repository
{
    public class ProjectRepository: GenericRepository<Project>, IProjectRepository
    {
        private GeneralContext context;
        private DbSet<Project> projects;

        public ProjectRepository(GeneralContext context): base(context)
        {
            this.context = context;
            projects = context.Set<Project>();
        }

        public IEnumerable<Project> GetProjectsByStatus(ProjectStatus status)
        {
            return projects.Where(p => p.Status.Equals(status));
        }
    }
}
