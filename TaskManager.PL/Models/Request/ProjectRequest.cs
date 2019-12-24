using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.PL.Models
{
    public class ProjectRequest
    {
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime Deadline { get; set; }
        public string CreatedByLogin { get; set; }
        public StatusResponse Status { get; set; }
    }
}
