using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.PL.Models
{
    public class EmployeeResponse
    {
        public Guid EmployeeId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual ICollection<EmployeeProjectResponse> EmployeeProjects { get; set; }
    }
}
