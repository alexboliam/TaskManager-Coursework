using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.Dtos
{
    public class EmployeeTaskDto
    {
        public Guid EmployeeId { get; set; }
        public Guid TaskId { get; set; }
        public virtual EmployeeDto Employee { get; set; }
        public virtual TaskDto Task { get; set; }
    }
}
