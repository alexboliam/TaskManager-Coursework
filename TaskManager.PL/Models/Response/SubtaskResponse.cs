using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.PL.Models
{
    public class SubtaskResponse
    {
        public Guid SubtaskId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
