using MarcAiAPI.Domain.Entities.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping;

public class StorePhotoMap : IEntityTypeConfiguration<StorePhoto>
{
    public void Configure(EntityTypeBuilder<StorePhoto> builder)
    {
        builder.ToTable("StorePhotos");
        
        builder.HasKey(p => p.PhotoId);

        builder.Property(p => p.PhotoId)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.PhotoUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(p => p.PhotoCaption)
            .HasMaxLength(255);

        builder.Property(p => p.IsMainPhoto)
            .IsRequired()
            .HasDefaultValue(false);
        
    }
}