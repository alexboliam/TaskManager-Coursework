using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.DAL.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Login must be less than 20 chars long")]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public virtual IEnumerable<EmployeeProject> AdminAtProjects { get; set; } // TODO: RENAME TO PROJECTS WHERE EMPLOYEE IS ADMIN
        public virtual IEnumerable<EmployeeTeam> TeamsWithThisEmployee { get; set; }
        public virtual IEnumerable<EmployeeTask> TasksFromEmployee { get; set; }


    }
}
