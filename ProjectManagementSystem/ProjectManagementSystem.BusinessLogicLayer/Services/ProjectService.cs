﻿using AutoMapper;
using ProjectManagementSystem.API.Repositories.UnitOfWork;
using ProjectManagementSystem.API.Services;
using ProjectManagementSystem.BusinessLogicLayer.Exceptions;
using ProjectManagementSystem.Draft;
using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.BusinessLogicLayer.Services
{
    public class ProjectService : IProjectService
    {
        private const string NOT_ADMIN = "User hasnt access! User arent admin.";

        private IUnitOfWork uow;

        public ProjectService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddUserToProject(long ProjectId, long UserId, string token)
        {
            throw new NotImplementedException();
        }

        public void CreateProject(ProjectViewDraft draft, string token)
        {
            throw new NotImplementedException();
        }

        public IList<ProjectViewDraft> GetAllWaitingProjects()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectViewDraft>());
            return Mapper.Map<IEnumerable<Project>, IList<ProjectViewDraft>>
                (uow.Projects.GetProjectsByStatus(ProjectStatus.WAITING));
        }

        public IList<ProjectViewDraft> GetAllDuringProjects()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectViewDraft>());
            return Mapper.Map<IEnumerable<Project>, IList<ProjectViewDraft>>
                (uow.Projects.GetProjectsByStatus(ProjectStatus.DURING));
        }

        public IList<ProjectViewDraft> GetAllFinishedProjects()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectViewDraft>());
            return Mapper.Map<IEnumerable<Project>, IList<ProjectViewDraft>>
                (uow.Projects.GetProjectsByStatus(ProjectStatus.FINISHED));
        }

        public IList<ProjectViewDraft> GetAllProjects()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Project, ProjectViewDraft>());
            return Mapper.Map<IEnumerable<Project>, IList<ProjectViewDraft>>(uow.Projects.GetAll());
        }

        public IList<UserViewDraft> GetUsersByProject(long ProjectId, string token)
        {
            throw new NotImplementedException();
        }

        public void RemoveUserFromProject(long ProjectId, long UserId, string token)
        {
            User currentUser = uow.Users.Get(TokenDictionary.Dictionary[token]);
            if(currentUser.Role != UserRole.ADMIN)
            {
                throw new CloseAccessException(NOT_ADMIN);
            }

            Project project = uow.Projects.Get(ProjectId);
            User user = uow.Users.Get(UserId);
            project.PatisipationHistory.Where(ph => ph.User.Equals(user) && ph.IsActive)
                .FirstOrDefault().IsActive = false;
            uow.Projects.Update(project);
            uow.Save();
        }
    }
}
