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
    public class UserRepository: IRepository<User>
    {
        private PMSContext context;

        public UserRepository(PMSContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User Get(long id)
        {
            return context.Users.Find(id);
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public void Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
        }
    }
}
