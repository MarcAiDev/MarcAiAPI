using MarcAiAPI.Domain.Entities.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping
{
    public class MarketplaceMap : IEntityTypeConfiguration<MarketplaceEntity>
    {
        public void Configure(EntityTypeBuilder<MarketplaceEntity> builder)
        {
            builder.ToTable("Marketplaces");
        
            builder.HasKey(m => m.MarketplaceId);
            
            builder.Property(a => a.MarketplaceId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Name)
                .HasMaxLength(100);
        
            builder.Property(m => m.Description)
                .HasMaxLength(500);
        
            builder.Property(m => m.Latitude)
                .HasMaxLength(30);
        
            builder.Property(m => m.Longitude)
                .HasMaxLength(30);

            builder
                .HasMany(m => m.Stores)
                .WithOne(s => s.Marketplace)
                .HasForeignKey(s => s.MarketplaceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}