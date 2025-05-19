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
        
    }
}