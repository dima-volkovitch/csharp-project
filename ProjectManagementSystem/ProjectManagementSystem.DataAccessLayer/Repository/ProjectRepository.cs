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
    public class ProjectRepository: IProjectRepository
    {
        private GeneralContext context;

        public ProjectRepository(GeneralContext context)
        {
            this.context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return context.Projects;
        }

        public Project Get(long id)
        {
            return context.Projects.Find(id);
        }

        public void Add(Project project)
        {
            context.Projects.Add(project);
        }

        public void Update(Project project)
        {
            context.Entry(project).State = EntityState.Modified;
        }

        public void Delete(long id)
        {
            Project project = context.Projects.Find(id);
            if(project != null)
            {
                context.Projects.Remove(project);
            }
        }
    }
}
