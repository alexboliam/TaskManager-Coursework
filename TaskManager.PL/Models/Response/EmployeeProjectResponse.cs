using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.PL.Models
{
    public class EmployeeProjectResponse
    {
        public Guid EmployeeId { get; set; }
        public virtual EmployeeResponse Employee { get; set; }
        public Guid ProjectId { get; set; }
        public virtual ProjectResponse Project { get; set; }
    }
}
