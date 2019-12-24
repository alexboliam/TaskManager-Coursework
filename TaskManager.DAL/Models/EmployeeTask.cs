using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DAL.Models
{
    public class EmployeeTask
    {
        public Guid EmployeeId { get; set; }
        public Guid TaskId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}
