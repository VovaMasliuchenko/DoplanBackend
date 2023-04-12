using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Doplan.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DoplanDBContext>
    {
            public DoplanDBContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DoplanDBContext>();

                optionsBuilder.UseSqlServer("Server=DESKTOP-L0COR8H\\SQLEXPRESS01; Database=Doplan;Integrated Security=True;");
                return new DoplanDBContext(optionsBuilder.Options);
            }   
    }
}
