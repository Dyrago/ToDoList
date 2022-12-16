using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList1.Models;

namespace ToDoList1.Data
{
    public class ToDoList1Context : DbContext
    {
        public ToDoList1Context (DbContextOptions<ToDoList1Context> options)
            : base(options)
        {
        }

        public DbSet<ToDoList1.Models.TaskViewModel> TaskViewModel { get; set; } = default!;
    }
}
