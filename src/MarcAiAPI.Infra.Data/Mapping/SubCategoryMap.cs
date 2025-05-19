using MarcAiAPI.Domain.Entities.Category;
using MarcAiAPI.Domain.Entities.Subcategory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping;

public class SubcategoryMap : IEntityTypeConfiguration<SubcategoryEntity>
{
    public void Configure(EntityTypeBuilder<SubcategoryEntity> builder)
    {
        builder.ToTable("Subcategories");

        builder.HasKey(s => s.SubcategoryId);

        builder.Property(s => s.SubcategoryName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.SubcategoryDescription)
            .HasMaxLength(255);
        
    }
}