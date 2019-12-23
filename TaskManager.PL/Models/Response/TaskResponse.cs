using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.PL.Models
{
    public class TaskResponse
    {
        public Guid TaskId { get; set; }
        public string Name { get; set; }
        public virtual StatusResponse Status { get; set; }
        public string LoginOfCreatedBy { get; set; }
        public DateTime Deadline { get; set; }
        public virtual ICollection<SubtaskResponse> Subtasks { get; set; }
    }
}
