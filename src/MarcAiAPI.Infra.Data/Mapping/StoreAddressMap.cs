using MarcAiAPI.Domain.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping
{
    public class StoreAddressMap : IEntityTypeConfiguration<StoreAddressEntity>
    {
        public void Configure(EntityTypeBuilder<StoreAddressEntity> builder)
        {
            builder.ToTable("StoreAddress");
            builder.HasKey(a => a.AddressId);

            builder.Property(a => a.AddressId)
                .IsRequired()
                .ValueGeneratedOnAdd();
        
            builder.Property(a => a.StoreId)
                .IsRequired();

            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Number)
                .IsRequired();

            builder.Property(a => a.Complement)
                .HasMaxLength(100);

            builder.Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Latitude)
                .HasMaxLength(30);

            builder.Property(a => a.Longitude)
                .HasMaxLength(30);
        }
    }
}