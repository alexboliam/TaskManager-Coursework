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
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
