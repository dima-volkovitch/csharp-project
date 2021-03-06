﻿using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.API.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsByStatus(ProjectStatus status);

        bool IsUserPaticipateInProject(long projectId, User user);

        IEnumerable<User> GetActiveProjectUsers(long projectId);
    }
}
