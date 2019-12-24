using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.PL.Models
{
    public class EmployeeTaskResponse
    {
        public Guid EmployeeId { get; set; }
        public Guid TaskId { get; set; }
        public virtual EmployeeResponse Employee { get; set; }
        public virtual TaskResponse Task { get; set; }
    }
}
