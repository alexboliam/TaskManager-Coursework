using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DAL.Models
{
    public class EmployeeProject
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
