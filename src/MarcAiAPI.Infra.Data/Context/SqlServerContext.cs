using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Entities.Category;
using MarcAiAPI.Domain.Entities.Person;
using MarcAiAPI.Domain.Entities.Review;
using MarcAiAPI.Domain.Entities.Seller;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Entities.Subcategory;
using MarcAiAPI.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MarcAiAPI.Infra.Data.Context;

public class SqlServerContext : DbContext
{
    public SqlServerContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<PersonEntity> Person { get; set; }
    
    public DbSet<StoreEntity> Store { get; set; }
    
    public DbSet<StoreAddressEntity> StoreAddress { get; set; }
    
    public DbSet<CategoryEntity> Category { get; set; }
    
    public DbSet<ReviewEntity> Review { get; set; }

    public DbSet<SellerEntity> Seller { get; set; }
    
    public DbSet<StorePhoto> StorePhoto { get; set; }
    
    public DbSet<SubcategoryEntity> Subcategory { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new PersonMap());
        modelBuilder.ApplyConfiguration(new StoreMap());
        modelBuilder.ApplyConfiguration(new StoreAddressMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new ReviewMap());
        modelBuilder.ApplyConfiguration(new SellerMap());
        modelBuilder.ApplyConfiguration(new StorePhotoMap());
        modelBuilder.ApplyConfiguration(new SubcategoryMap());
    }
}