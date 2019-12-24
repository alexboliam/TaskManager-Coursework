using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.PL.Models
{
    public class TaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusResponse Status { get; set; }
        public string LoginOfCreatedBy { get; set; }
        public DateTime Deadline { get; set; }
    }
}
