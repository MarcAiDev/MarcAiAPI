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
    }
}