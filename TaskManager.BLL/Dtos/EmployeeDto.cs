using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.BLL.Dtos
{
    public class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<EmployeeTeamDto> TeamsWithThisEmployee { get; set; }
        public virtual ICollection<EmployeeTaskDto> TasksFromEmployee { get; set; }

    }
}
