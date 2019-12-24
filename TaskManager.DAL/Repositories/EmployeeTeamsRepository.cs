using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repositories
{
    internal class EmployeeTeamsRepository : RepositoryBase<EmployeeTeam>, IEmployeeTeamsRepository
    {
        public EmployeeTeamsRepository(TaskManagerContext context):base(context)
        {

        }
    }
}
