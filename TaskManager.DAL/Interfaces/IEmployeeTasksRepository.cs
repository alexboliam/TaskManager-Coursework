using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Models;
using TaskManager.DAL.Repositories;

namespace TaskManager.DAL.Interfaces
{
    public interface IEmployeeTasksRepository : IRepositoryBase<EmployeeTask>
    {
    }
}
