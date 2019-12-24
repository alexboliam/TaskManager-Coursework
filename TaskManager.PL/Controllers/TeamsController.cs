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
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        IMapper mapper;
        ITeamService teamService;

        public TeamsController(ITeamService teamService, IMapper mapper)
        {
            this.teamService = teamService;
            this.mapper = mapper;
        }

        [HttpGet("{teamId}")]
        public IActionResult GetTeamById(Guid teamId)
        {
            try
            {
                var teams = teamService.GetTeamById(teamId);
                if (teams!= null)
                {
                    return Ok(mapper.Map<TeamResponse>(teams));
                }
                else
                {
                    return StatusCode(404, "Team not found");
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPut("{teamId}")]
        public IActionResult UpdateTeam(Guid teamId, [FromBody] TeamResponse team)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                var newTeam = mapper.Map<TeamDto>(team);
                newTeam.TeamId = teamId;
                var updated = teamService.UpdateTeam(newTeam);
                if (updated)
                {
                    return StatusCode(201, "Task was updated");
                }
                else
                {
                    return StatusCode(404, "Task not found");
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }


    }
}