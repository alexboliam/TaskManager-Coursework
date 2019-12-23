using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.PL.Models
{
    public class EmployeeTeamResponse
    {
        public Guid EmployeeId { get; set; }
        public virtual EmployeeResponse Employee { get; set; }
        public Guid TeamId { get; set; }
        public virtual TeamResponse Team { get; set; }
    }
}
