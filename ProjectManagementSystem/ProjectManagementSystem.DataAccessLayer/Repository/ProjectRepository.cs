using ProjectManagementSystem.API.Repository;
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
    public class ProjectRepository: IRepository<Project> 
    {
        private PMSContext context;

        public ProjectRepository(PMSContext context)
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

        public void Delete(Project project)
        {
            context.Projects.Remove(project);
        }
    }
}
