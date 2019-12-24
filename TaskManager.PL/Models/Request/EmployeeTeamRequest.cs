using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.PL.Models
{
    public class EmployeeTeamRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid TeamId { get; set; }
    }
}
