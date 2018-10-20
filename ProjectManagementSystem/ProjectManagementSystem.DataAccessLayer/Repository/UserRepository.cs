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
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        private GeneralContext context;
        private DbSet<User> users;

        public UserRepository(GeneralContext context) : base(context)
        {
            this.context = context;
            users = context.Set<User>();
        }

        public User GetByLogin(string login)
        {
            return users.Where(u => u.Login.Equals(login)).FirstOrDefault();
        }

        public IEnumerable<Project> GetActiveUserProjects(long userId)
        {
            return users.Find(userId).PaticipationHistory.
                Where(paticipationHistory => paticipationHistory.IsActive).
                Select(paticipationHistory => paticipationHistory.Project);
        }

        public IEnumerable<Project> GetActiveUserProjects(User user)
        {
            return user.PaticipationHistory.
                Where(paticipationHistory => paticipationHistory.IsActive).
                Select(paticipationHistory => paticipationHistory.Project);
        }
    }
}
