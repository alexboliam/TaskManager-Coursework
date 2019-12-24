using System;
using System.Collections.Generic;

namespace TaskManager.PL.Models
{
    public class TeamResponse
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EmployeeTeamResponse> TeamMembers { get; set; }
    }
}
