using MarcAiAPI.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(p => p.UserId);

            builder.Property(p => p.UserId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(p => p.Email)
                .IsRequired() 
                .HasMaxLength(100);

            builder.Property(p => p.Photo);

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(255);
            
        }
    }
}