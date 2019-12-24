using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.Dtos;

namespace TaskManager.BLL.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDto GetEmployeeByLogin(string login);
        bool AddToTeam(EmployeeTeamDto employeeTeam);
        bool DeleteFromTeam(EmployeeTeamDto employeeTeam);
        bool AddToTask(EmployeeTaskDto employeeTask);
        bool DeleteFromTask(EmployeeTaskDto employeeTask);

    }
}
