using MarcAiAPI.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcAiAPI.Infra.Data.Mapping
{
    public class PersonMap : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.ToTable("Person");
            builder.Ignore(x => x.Id);
            
            builder.HasKey(x => x.PersonId);
            
            builder.Property(x => x.PersonId)
                .IsRequired()
                .HasColumnName("PersonId")
                .HasColumnType("SERIAL");
            
            builder.Property(x => x.FullName)
                .IsRequired()
                .HasColumnName("FullName")
                .HasColumnType("varchar(100)");
            
            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(50)");
            
            builder.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("varchar(11)");
            
            builder.Property(x => x.DateOfBirth)
                .HasColumnName("DateOfBirth")
                .HasColumnType("DATE");
            
            builder.Property(x => x.Gender)
                .HasColumnName("Gender")
                .HasColumnType("varchar(1)");
        }
    }
}