using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.BLL.Dtos
{
    public class TeamDto
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EmployeeDto> Members { get; set; }
    }
}
