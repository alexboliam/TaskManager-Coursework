using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.BLL.Interfaces;
using TaskManager.PL.Models;

namespace TaskManager.PL.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        IProjectService projectService;
        IMapper mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            this.mapper = mapper;
            this.projectService = projectService;
        }

        [HttpGet("{employeeLogin}")]
        public IActionResult GetProjectsByEmployeeLogin(string employeeLogin)
        {
            try
            {
                var projects = projectService.GetProjectsByEmployeeLogin(employeeLogin);

                if (projects != null)
                {
                    return Ok(mapper.Map<IEnumerable<ProjectResponse>>(projects));
                }
                else
                {
                    return StatusCode(404, "Requested login was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. " + ex.Message);
            }
        }
    }
}