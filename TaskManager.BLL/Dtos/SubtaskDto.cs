using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.BLL.Dtos
{
    public class SubtaskDto
    {
        public Guid SubtaskId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual TaskDto PanentTask { get; set; }
    }
}
