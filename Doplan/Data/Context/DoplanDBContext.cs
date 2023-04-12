using Doplan.Data.Configurations;
using Doplan.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Doplan.Data.Context
{
    public class DoplanDBContext : IdentityDbContext<User>
    {

        public DbSet<TaskToDo> TaskToDo { get; set; }

        public DoplanDBContext(DbContextOptions<DoplanDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskToDoConfig());
        }
    }
}
