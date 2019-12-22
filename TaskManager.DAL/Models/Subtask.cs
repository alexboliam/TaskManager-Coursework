using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.DAL.Models
{
    public class Subtask
    {
        public Guid SubtaskId { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Max length of subtask is 1000 chars")]
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual Task ParentTask { get; set; }
    }
}
