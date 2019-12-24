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
    public class TeamService : ITeamService
    {
        IMapper mapper;
        IUnitOfWork unit;
        public TeamService(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public TeamDto GetTeamById(Guid teamId)
        {
            var team = unit.Teams.FindByCondition(x => x.TeamId.Equals(teamId)).FirstOrDefault();
            if (team == null)
            {
                return null;
            }

            return mapper.Map<TeamDto>(team);
        }

        public bool UpdateTeam(TeamDto team)
        {
            var updTeam = unit.Teams.FindByCondition(x => x.TeamId.Equals(team.TeamId)).FirstOrDefault();
            if (updTeam == null)
            {
                return false;
            }

            updTeam.Name = team.Name;
            updTeam.TeamMembers = mapper.Map<ICollection<EmployeeTeam>>(team.TeamMembers);

            unit.Teams.Update(updTeam);
            unit.Save();
            return true;
        }
    }
}
