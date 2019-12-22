using System;

namespace TaskManager.BLL.Dtos
{
    public class EmployeeTeamDto
    {
        public Guid EmployeeId { get; set; }
        public virtual EmployeeDto Employee { get; set; }
        public Guid TeamId { get; set; }
        public virtual TeamDto Team { get; set; }
    }
}
