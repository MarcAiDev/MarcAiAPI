using MarcAiAPI.Domain.Entities.Seller;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping;

public class SellerMap : IEntityTypeConfiguration<SellerEntity>
{
    public void Configure(EntityTypeBuilder<SellerEntity> builder)
    {
        builder.ToTable("Sellers");

        builder.HasKey(s => s.SellerId);

        builder.Property(s => s.IsVerified)
            .IsRequired()
            .HasDefaultValue(false);

        builder
            .HasOne(s => s.Person)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(s => s.Stores)
            .WithOne(store => store.Seller)
            .HasForeignKey("StoreId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}