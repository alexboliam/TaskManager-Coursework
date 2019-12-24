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
        public StatusResponse Status { get; set; }
        //public TeamResponse Team { get; set; }
        //public IEnumerable<TaskResponse> Tasks { get; set; }
        //public IEnumerable<EmployeeProjectResponse> ProjectAdministrators { get; set; }
    }
}
