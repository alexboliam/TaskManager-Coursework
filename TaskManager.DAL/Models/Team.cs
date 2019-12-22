using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DAL.Models
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Members { get; set; }
    }
}
