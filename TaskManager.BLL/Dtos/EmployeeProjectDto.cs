using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.Dtos
{
    public class EmployeeProjectDto
    {
        public Guid EmployeeId { get; set; }
        public virtual EmployeeDto Employee { get; set; }
        public Guid ProjectId { get; set; }
        public virtual ProjectDto Project { get; set; }
    }
}
