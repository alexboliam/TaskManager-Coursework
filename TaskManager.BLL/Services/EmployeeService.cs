using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.BLL.Dtos;
using TaskManager.BLL.Interfaces;
using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        IMapper mapper;
        IUnitOfWork unit;

        public EmployeeService(IUnitOfWork unit, IMapper mapper)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public bool AddToTask(EmployeeTaskDto employeeTask)
        {
            var newEmployeeTask = mapper.Map<EmployeeTask>(employeeTask);
            newEmployeeTask.Employee = unit.Employees.FindByCondition(x => x.EmployeeId.Equals(employeeTask.EmployeeId)).FirstOrDefault();
            newEmployeeTask.Task = unit.Tasks.FindByCondition(x => x.TaskId.Equals(employeeTask.TaskId)).FirstOrDefault();

            unit.EmployeeTasks.Create(newEmployeeTask);
            unit.Save();
            return true;
        }

        public bool AddToTeam(EmployeeTeamDto employeeTeam)
        {
            var newEmployeeTeam = mapper.Map<EmployeeTeam>(employeeTeam);
            newEmployeeTeam.Employee = unit.Employees.FindByCondition(x => x.EmployeeId.Equals(employeeTeam.EmployeeId)).FirstOrDefault();
            newEmployeeTeam.Team = unit.Teams.FindByCondition(x => x.TeamId.Equals(employeeTeam.TeamId)).FirstOrDefault();
             
            unit.EmployeeTeams.Create(newEmployeeTeam);
            unit.Save();
            return true;
        }

        public bool DeleteFromTask(EmployeeTaskDto employeeTask)
        {
            var newEmployeeTask = mapper.Map<EmployeeTask>(employeeTask);
            newEmployeeTask.Employee = unit.Employees.FindByCondition(x => x.EmployeeId.Equals(employeeTask.EmployeeId)).FirstOrDefault();
            newEmployeeTask.Task = unit.Tasks.FindByCondition(x => x.TaskId.Equals(employeeTask.TaskId)).FirstOrDefault();

            unit.EmployeeTasks.Delete(newEmployeeTask);
            unit.Save();
            return true;
        }

        public bool DeleteFromTeam(EmployeeTeamDto employeeTeam)
        {
            var newEmployeeTeam = mapper.Map<EmployeeTeam>(employeeTeam);
            newEmployeeTeam.Employee = unit.Employees.FindByCondition(x => x.EmployeeId.Equals(employeeTeam.EmployeeId)).FirstOrDefault();
            newEmployeeTeam.Team = unit.Teams.FindByCondition(x => x.TeamId.Equals(employeeTeam.TeamId)).FirstOrDefault();

            unit.EmployeeTeams.Delete(newEmployeeTeam);
            unit.Save();
            return true;
        }

        public EmployeeDto GetEmployeeByLogin(string login)
        {
            var emp = unit.Employees.FindByCondition(x => x.Login == login).FirstOrDefault();
            if(emp == null)
            {
                return null;
            }
            return mapper.Map<EmployeeDto>(emp);
        }

        public bool RemoveFromTask(EmployeeTaskDto employeeTask)
        {
            throw new NotImplementedException();
        }
    }
}
