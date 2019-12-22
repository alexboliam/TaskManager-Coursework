using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repositories
{
    internal class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}
