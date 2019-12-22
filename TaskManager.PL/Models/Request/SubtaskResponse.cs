using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.PL.Models
{
    public class SubtaskRequest
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public Guid ParentTaskId { get; set; }
    }
}
