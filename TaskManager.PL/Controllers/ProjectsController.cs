using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.BLL.Dtos;
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

        [HttpGet("{projectId}/team")]
        public IActionResult GetTeamByProjectId(Guid projectId)
        {
            try
            {
                var team = projectService.GetTeamByProjectId(projectId);

                if (team != null)
                {
                    return Ok(mapper.Map<TeamResponse>(team));
                }
                else
                {
                    return StatusCode(404, "Requested project was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. " + ex.Message);
            }
        }

        [HttpGet("{employeeLogin}")]
        public IActionResult GetProjectsByEmployeeLogin(string employeeLogin)
        {
            try
            {
                var projects = projectService.GetProjectsByEmployeeLogin(employeeLogin);

                if (projects != null)
                {
                    return Ok(mapper.Map<ICollection<ProjectResponse>>(projects));
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

        [HttpGet("byid/{projectId}")]
        public IActionResult GetProjectsByProjectId(Guid projectId)
        {
            try
            {
                var project = projectService.GetProjectByProjectId(projectId);

                if (project != null)
                {
                    return Ok(mapper.Map<ProjectResponse>(project));
                }
                else
                {
                    return StatusCode(404, "Requested project was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. " + ex.Message);
            }
        }

        [HttpPost()]
        public IActionResult CreateProject([FromBody] ProjectRequest project)
        {
            try
            {
                var created = projectService.CreateProject(mapper.Map<ProjectDto>(project));

                if (created != false)
                {
                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(404, "Something not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. " + ex.Message);
            }
        }

    }
}