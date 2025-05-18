using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Entities.Category;
using MarcAiAPI.Domain.Entities.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping;

public class StoreMap : IEntityTypeConfiguration<StoreEntity>
{
    public void Configure(EntityTypeBuilder<StoreEntity> builder)
    {
        builder.ToTable("Stores");

        builder.HasKey(s => s.StoreId);

        builder.Property(s => s.CpfCnpj)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(s => s.StoreName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.StoreDescription)
            .HasMaxLength(255);

        builder.Property(s => s.OpeningHours)
            .HasMaxLength(100);

        builder.Property(s => s.IsOpen)
            .IsRequired();

        builder.HasOne(s => s.Seller)
            .WithMany(seller => seller.Stores)
            .HasForeignKey("SellerId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Reviews)
            .WithOne(r => r.Store)
            .HasForeignKey("ReviewId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.Categories)
            .WithMany(c => c.Stores)
            .UsingEntity<Dictionary<string, object>>(
                "StoreCategory",
                j => j
                    .HasOne<CategoryEntity>()
                    .WithMany()
                    .HasForeignKey("CategoryId"),
                j => j
                    .HasOne<StoreEntity>()
                    .WithMany()
                    .HasForeignKey("StoreId"),
                j =>
                {
                    j.HasKey("StoreId", "CategoryId");
                    j.ToTable("StoreCategories");
                });

        builder.HasOne(s => s.StoreAddress)
            .WithOne(a => a.Store)
            .HasForeignKey<StoreAddressEntity>("AddressId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.Photos)
            .WithOne(p => p.Store)
            .HasForeignKey("PhotoId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}