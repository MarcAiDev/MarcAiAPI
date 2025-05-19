using MarcAiAPI.Domain.Entities.Person;
using MarcAiAPI.Domain.Entities.Review;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping;

public class ReviewMap : IEntityTypeConfiguration<ReviewEntity>
{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.ToTable("Review");
        builder.HasKey(x => x.ReviewId);

        builder.Property(x => x.ReviewId)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.ReviewRating)
            .IsRequired()
            .HasColumnType("decimal(3,2)");

        builder.Property(x => x.ReviewTitle)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.ReviewText)
            .IsRequired()
            .HasMaxLength(2000);
    }
}