using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.PL.Models
{
    public class ProjectResponse
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime Deadline { get; set; }
        public virtual StatusResponse Status { get; set; }
        public virtual TeamResponse Team { get; set; }
        public virtual ICollection<TaskResponse> Tasks { get; set; }
        public virtual ICollection<EmployeeProjectResponse> ProjectAdministrators { get; set; }
    }
}
