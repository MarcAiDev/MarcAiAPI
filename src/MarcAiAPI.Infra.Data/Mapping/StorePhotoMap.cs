using MarcAiAPI.Domain.Entities.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping;

public class StorePhotoMap : IEntityTypeConfiguration<StorePhoto>
{
    public void Configure(EntityTypeBuilder<StorePhoto> builder)
    {
        builder.ToTable("StorePhotos");

        // PK
        builder.HasKey(p => p.PhotoId);

        builder.Property(p => p.PhotoId)
            .IsRequired()
            .ValueGeneratedOnAdd();

        // Campos
        builder.Property(p => p.PhotoUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.PhotoCaption)
            .HasMaxLength(255);

        builder.Property(p => p.IsMainPhoto)
            .IsRequired()
            .HasDefaultValue(false);

        builder.HasOne(p => p.Store)
            .WithMany(s => s.Photos)
            .HasForeignKey("StoreId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}