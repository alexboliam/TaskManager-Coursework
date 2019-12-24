using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.BLL.Dtos;
using TaskManager.BLL.Interfaces;
using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services
{
    public class ProjectService : IProjectService
    {
        IMapper mapper;
        IUnitOfWork unit;
        public ProjectService(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }


        public ICollection<ProjectDto> GetProjectsByEmployeeLogin(string login)
        {
            var employee = unit.Employees.FindByCondition(x => x.Login.Equals(login)).FirstOrDefault();
            if (employee == null)
            {
                return null;
            }

            var prs = unit.Projects.FindByCondition(p => p.Team.TeamMembers.Any(x => x.Employee.Equals(employee))).ToList();
            foreach(var proj in prs)
            {
                UpdateProjectStatuses(mapper.Map<ProjectDto>(proj));
            }

            var projects = unit.Projects.FindByCondition(p => p.Team.TeamMembers.Any(x => x.Employee.Equals(employee))).ToList();

            return mapper.Map<ICollection<ProjectDto>>(projects);
        }
        public ProjectDto GetProjectByProjectId(Guid projectId)
        {
            var pr = unit.Projects.FindByCondition(x => x.ProjectId.Equals(projectId)).FirstOrDefault();
            UpdateProjectStatuses(mapper.Map<ProjectDto>(pr));
            var project = unit.Projects.FindByCondition(x => x.ProjectId.Equals(projectId)).FirstOrDefault();
            if (project == null)
            {
                return null;
            }

            return mapper.Map<ProjectDto>(project);
        }
        public TeamDto GetTeamByProjectId(Guid projectId)
        {
            var team = unit.Projects.FindByCondition(x => x.ProjectId.Equals(projectId)).FirstOrDefault().Team;
            if (team == null)
            {
                return null;
            }

            return mapper.Map<TeamDto>(team);
        }

        public bool CreateProject(ProjectDto project)
        {
            var employee = unit.Employees.FindByCondition(x => x.Login == project.CreatedByLogin).FirstOrDefault();
            var team = new Team() { Name = project.Name, TeamMembers = new List<EmployeeTeam>() };
            var newProject = mapper.Map<Project>(project);
            newProject.Team = team;
            newProject.Team.TeamMembers.Add(new EmployeeTeam() { EmployeeId = employee.EmployeeId, Employee = employee, Team = team});
            newProject.Status = Status.Created;
            
            unit.Projects.Create(newProject);
            unit.Save();
            return true;
        }

        public void UpdateProjectStatuses(ProjectDto project)
        {
            var updProject = unit.Projects.FindByCondition(x => x.ProjectId == project.ProjectId).FirstOrDefault();
            if(updProject.Tasks.Count<1)
            {
                return;
            }
            if(updProject.Tasks.All(x=>x.Status == Status.Done))
            {
                updProject.Status = Status.Done;
            }
            else if(updProject.Tasks.Any(x=>x.Status==Status.InProgress || x.Status == Status.Overdue))
            {
                updProject.Status = Status.InProgress;
            }
            else if (updProject.Tasks.All(x => x.Status == Status.Overdue || x.Deadline < DateTime.Now))
            {
                updProject.Status = Status.Overdue;
            }
            unit.Projects.Update(updProject);
            unit.Save();
        }
    }
}
