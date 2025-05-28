using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Entities.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping
{
    public class StoreMap : IEntityTypeConfiguration<StoreEntity>
    {
        public void Configure(EntityTypeBuilder<StoreEntity> builder)
        {
            builder.ToTable("Stores");

            builder.HasKey(s => s.StoreId);

            builder.Property(s => s.StoreId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(s => s.SellerId) 
                .IsRequired();

            builder.Property(s => s.MarketplaceId) 
                .IsRequired();

            builder.Property(s => s.Cnpj)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Description)
                .HasMaxLength(255);

            builder.Property(s => s.Photo);

            builder.Property(s => s.IsActive)
                .IsRequired();

            builder.Property(s => s.Category)
                .HasMaxLength(50);
            
            builder.HasOne(s => s.Seller) 
                   .WithMany(seller => seller.Stores) 
                   .HasForeignKey(s => s.SellerId)
                   .OnDelete(DeleteBehavior.Cascade); 
            
            builder.HasOne(s => s.StoreAddress) 
                   .WithOne(sa => sa.Store) 
                   .HasForeignKey<StoreAddressEntity>(a => a.StoreId) 
                   .OnDelete(DeleteBehavior.Cascade); 
            
            builder.HasOne(s => s.Marketplace) 
                   .WithMany(m => m.Stores) 
                   .HasForeignKey(s => s.MarketplaceId)
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}