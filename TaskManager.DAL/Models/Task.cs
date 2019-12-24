using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DAL.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Status Status { get; set; }
        public virtual Employee CreatedBy { get; set; }
        public DateTime Deadline { get; set; }
        public virtual ICollection<EmployeeTask> EmployeesOnTask { get; set; }
        public virtual ICollection<Subtask> Subtasks { get; set; }
    }
}
