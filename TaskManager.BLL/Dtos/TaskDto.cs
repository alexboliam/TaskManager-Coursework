using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.Dtos
{
    public class TaskDto
    {
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual StatusDto Status { get; set; }
        public virtual EmployeeDto CreatedBy { get; set; }
        public DateTime Deadline { get; set; }
        public virtual ICollection<EmployeeTaskDto> EmployeesOnTask { get; set; }
        public virtual ICollection<SubtaskDto> Subtasks { get; set; }
    }
}
