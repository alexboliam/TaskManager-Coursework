using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace TaskManager.PL.Models
{
    public enum StatusResponse
    {
        Created,
        InProgress,
        Done,
        Overdue        
    }
}
