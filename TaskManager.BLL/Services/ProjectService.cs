﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.BLL.Dtos;
using TaskManager.BLL.Interfaces;
using TaskManager.DAL.Interfaces;

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


        public IEnumerable<ProjectDto> GetProjectsByEmployeeLogin(string login)
        {
            var employee = unit.Employees.FindByCondition(x => x.Login.Equals(login)).FirstOrDefault();
            if (employee == null)
            {
                return null;
            }

            var projects = unit.Projects.FindByCondition(p => p.Team.TeamMembers.Any(x => x.Employee.Equals(employee))).ToList();
            return mapper.Map<IEnumerable<ProjectDto>>(projects);
        }
    }
}