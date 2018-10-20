﻿using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.API.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLogin(string login);

        IEnumerable<Project> GetActiveUserProjects(long userId);

        IEnumerable<Project> GetActiveUserProjects(User user);
    }
}
