using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace TaskManager.DAL.Models
{
    public enum Status
    {
        Created,
        InProgress,
        Done,
        Overdue        
    }
}
