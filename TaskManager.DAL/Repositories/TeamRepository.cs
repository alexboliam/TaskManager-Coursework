using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repositories
{
    internal class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}
