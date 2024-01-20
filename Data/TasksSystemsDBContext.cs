using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TarefasApp.Data.Map;
using TarefasApp.Models;

namespace TarefasApp.Data
{
    public class TasksSystemsDBContext : DbContext
    {
        public TasksSystemsDBContext(DbContextOptions<TasksSystemsDBContext> options)
            : base(options)
            {

            }

            public DbSet<UserModel> Users { get; set; }
            public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}