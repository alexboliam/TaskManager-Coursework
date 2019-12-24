using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repositories
{
    internal class EmployeeTasksRepository : RepositoryBase<EmployeeTask>, IEmployeeTasksRepository
    {
        public EmployeeTasksRepository(TaskManagerContext context):base(context)
        {

        }
    }
}
