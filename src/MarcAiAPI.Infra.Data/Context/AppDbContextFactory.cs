using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MarcAiAPI.Infra.Data.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseNpgsql("Server=marcai.postgres.database.azure.com;Database=postgres;Port=5432;User Id=marcai;Password=m4rc41*123;Ssl Mode=Require;");
        
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
