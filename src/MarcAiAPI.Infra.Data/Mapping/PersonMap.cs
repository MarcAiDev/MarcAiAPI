using MarcAiAPI.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping;

public class PersonMap : IEntityTypeConfiguration<PersonEntity>
{
    public void Configure(EntityTypeBuilder<PersonEntity> builder)
    {
        builder.ToTable("Persons");

        builder.HasKey(p => p.PersonId);

        builder.Property(p => p.FullName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(p => p.DateOfBirth)
            .IsRequired();

        builder.Property(p => p.Password)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.IsSeller)
            .IsRequired();

        // 1:N → Reviews
        builder.HasMany(p => p.Reviews)
            .WithOne(r => r.Person)
            .HasForeignKey("StoreId")
            .OnDelete(DeleteBehavior.Cascade);

        // 1:1 → Seller
        builder.HasOne(p => p.Seller)
            .WithOne(s => s.Person)
            .HasForeignKey("PersonId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}