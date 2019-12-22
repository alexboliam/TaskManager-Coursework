using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.Dtos
{
    public class ProjectDto
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime Deadline { get; set; }
        public virtual StatusDto Status { get; set; }
        public virtual TeamDto Team { get; set; }
        public virtual ICollection<TaskDto> Tasks { get; set; }
        public virtual ICollection<EmployeeProjectDto> ProjectAdministrators { get; set; }
    }
}
