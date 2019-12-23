using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DAL.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime Deadline { get; set; }
        public virtual Status Status { get; set; }
        public virtual Team Team { get; set; }
        public virtual IEnumerable<Task> Tasks { get; set; }
        public virtual IEnumerable<EmployeeProject> ProjectAdministrators { get; set; }
    }
}
