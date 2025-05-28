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

        builder.Property(s => s.SellerId)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(s => s.UserId)
            .IsRequired();

        builder.HasOne(s => s.User)
            .WithOne(u => u.SellerProfile)
            .HasForeignKey<SellerEntity>(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(s => s.UserId)
            .IsUnique();

        builder.HasMany(s => s.Stores)
            .WithOne(st => st.Seller)
            .HasForeignKey(st => st.SellerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}