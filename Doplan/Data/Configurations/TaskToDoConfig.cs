using Doplan.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doplan.Data.Configurations
{
    public class TaskToDoConfig : IEntityTypeConfiguration<TaskToDo>
    {
        public void Configure(EntityTypeBuilder<TaskToDo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.ToDoUser)
                   .WithMany(d => d.todoList)
                   .HasForeignKey(k => k.Id_User);

            builder.Property(e => e.Text)
                   .HasMaxLength(100)
                   .IsRequired();
        }
    }
}
