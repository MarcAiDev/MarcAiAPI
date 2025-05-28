using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Entities.Seller;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Entities.User;
using MarcAiAPI.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MarcAiAPI.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
        public DbSet<UserEntity> User { get; set; }
    
        public DbSet<StoreEntity> Store { get; set; }
    
        public DbSet<StoreAddressEntity> StoreAddress { get; set; }
    
        public DbSet<MarketplaceEntity> Marketplace { get; set; }
        public DbSet<SellerEntity> Seller { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new StoreMap());
            modelBuilder.ApplyConfiguration(new SellerMap());
            modelBuilder.ApplyConfiguration(new StoreAddressMap());
            modelBuilder.ApplyConfiguration(new MarketplaceMap());
        }
    }
}