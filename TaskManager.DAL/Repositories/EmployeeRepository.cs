using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repositories
{
    internal class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}
