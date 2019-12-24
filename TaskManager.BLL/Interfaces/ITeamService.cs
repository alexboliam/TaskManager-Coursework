using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.Dtos;

namespace TaskManager.BLL.Interfaces
{
    public interface ITeamService
    {
        bool UpdateTeam(TeamDto team);
        TeamDto GetTeamById(Guid teamId);
    }
}
