using MarcAiAPI.Domain.Entities.Category;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Entities.Subcategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping;

public class CategoryMap : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(c => c.CategoryId);

        builder.Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.CategoryDescription)
            .HasMaxLength(255);

        builder
            .HasMany(c => c.Subcategories)
            .WithMany(s => s.Categories)
            .UsingEntity<Dictionary<string, object>>(
                "CategorySubcategory",
                j => j
                    .HasOne<SubcategoryEntity>()
                    .WithMany()
                    .HasForeignKey("SubcategoryId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<CategoryEntity>()
                    .WithMany()
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("CategoryId", "SubcategoryId");
                    j.ToTable("CategorySubcategories");
                });

        builder
            .HasMany(c => c.Stores)
            .WithMany(s => s.Categories)
            .UsingEntity<Dictionary<string, object>>(
                "CategoryStore",
                j => j
                    .HasOne<StoreEntity>()
                    .WithMany()
                    .HasForeignKey("StoreId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<CategoryEntity>()
                    .WithMany()
                    .HasForeignKey("CategoryId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("CategoryId", "StoreId");
                    j.ToTable("CategoryStores");
                });
    }
}