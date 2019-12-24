using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DAL.Interfaces;

namespace TaskManager.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private TaskManagerContext context;
        private IEmployeeRepository employees;
        private IProjectRepository projects;
        private ITaskRepository tasks;
        private ISubtaskRepository subtasks;
        private ITeamRepository teams;
        private IEmployeeTeamsRepository employeeTeams;
        private IEmployeeTasksRepository employeeTasks;

        public UnitOfWork(TaskManagerContext context)
        {
            this.context = context;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public IEmployeeTeamsRepository EmployeeTeams
        {
            get
            {
                if (employeeTeams == null)
                {
                    employeeTeams = new EmployeeTeamsRepository(context);
                }
                return employeeTeams;
            }
        }
        public IEmployeeTasksRepository EmployeeTasks
        {
            get
            {
                if (employeeTasks == null)
                {
                    employeeTasks = new EmployeeTasksRepository(context);
                }
                return employeeTasks;
            }
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if (employees == null)
                {
                    employees = new EmployeeRepository(context);
                }
                return employees;
            }
        }
        public IProjectRepository Projects
        {
            get
            {
                if (projects == null)
                {
                    projects = new ProjectRepository(context);
                }
                return projects;
            }
        }
        public ITaskRepository Tasks
        {
            get
            {
                if (tasks == null)
                {
                    tasks = new TaskRepository(context);
                }
                return tasks;
            }
        }
        public ISubtaskRepository Subtasks
        {
            get
            {
                if (subtasks == null)
                {
                    subtasks = new SubtaskRepository(context);
                }
                return subtasks;
            }
        }
        public ITeamRepository Teams
        {
            get
            {
                if (teams == null)
                {
                    teams = new TeamRepository(context);
                }
                return teams;
            }
        }
    }
}
