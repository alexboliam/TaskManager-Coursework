using System;
using System.Collections.Generic;

namespace TaskManager.PL.Models
{
    public class TeamRequest
    {
        public string Name { get; set; }
        public virtual ICollection<EmployeeResponse> Members { get; set; }
    }
}
