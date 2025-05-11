using MarcAiAPI.Domain.Entities.Person;
using MarcAiAPI.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MarcAiAPI.Infra.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PersonEntity> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonEntity>(new PersonMap().Configure);
        }
    }
}
