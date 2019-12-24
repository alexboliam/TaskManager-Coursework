using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.PL.Models
{
    public class EmployeeTaskRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid TaskId { get; set; }
    }
}
