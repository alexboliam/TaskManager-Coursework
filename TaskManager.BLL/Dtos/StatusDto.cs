using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace TaskManager.BLL.Dtos
{
    public enum StatusDto
    {
        Created,
        InProgress,
        Done,
        Overdue        
    }
}
