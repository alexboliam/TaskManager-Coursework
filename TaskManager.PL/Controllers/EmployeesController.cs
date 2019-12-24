using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.BLL.Dtos;
using TaskManager.BLL.Interfaces;
using TaskManager.PL.Models;

namespace TaskManager.PL.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService employeeService;
        IMapper mapper;
        public EmployeesController(IMapper mapper, IEmployeeService employeeService)
        {
            this.mapper = mapper;
            this.employeeService = employeeService;
        }

        [HttpGet("{login}")]
        public IActionResult GetEmployeeByLogin(string login)
        {
            try
            {
                var employee = employeeService.GetEmployeeByLogin(login);
                if (employee == null)
                {
                    return StatusCode(404, "Employee not found");
                }
                return Ok(employee);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("team/")]
        public IActionResult AddToTeam([FromBody] EmployeeTeamRequest employeeTeam)
        {
            try
            {
                var added = employeeService.AddToTeam(mapper.Map<EmployeeTeamDto>(employeeTeam));
                if (!added)
                {
                    return StatusCode(404, "Employee not found");
                }
                return StatusCode(201, "Added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpDelete("team/{teamid}")]
        public IActionResult DeleteFromTeam([FromBody] EmployeeTeamRequest employeeTeam)
        {
            try
            {
                var deleted = employeeService.DeleteFromTeam(mapper.Map<EmployeeTeamDto>(employeeTeam));
                if (!deleted)
                {
                    return StatusCode(404, "Employee not found");
                }
                return StatusCode(204, "Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost("{employeeId}/tasks")]
        public IActionResult AddToTask(Guid employeeId, [FromBody] EmployeeTaskRequest employeeTask)
        {
            try
            {
                employeeTask.EmployeeId = employeeId;
                var added = employeeService.AddToTask(mapper.Map<EmployeeTaskDto>(employeeTask));
                if (!added)
                {
                    return StatusCode(404, "Task not found");
                }
                return StatusCode(201, "Added");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpDelete("tasks/{taskId}")]
        public IActionResult DeleteFromTask([FromBody] EmployeeTaskRequest employeeTask)
        {
            try
            {
                var deleted = employeeService.DeleteFromTask(mapper.Map<EmployeeTaskDto>(employeeTask));
                if (!deleted)
                {
                    return StatusCode(404, "Employee not found");
                }
                return StatusCode(204, "Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}