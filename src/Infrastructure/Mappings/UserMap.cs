using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CPF)
                .HasColumnName("cpf")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(255);

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(255);

            builder.Property(x => x.FullName)
                .HasColumnName("full_name")
                .HasMaxLength(255);

            builder.Property(x => x.PreferredName)
                .HasColumnName("preferred_name")
                .HasMaxLength(255);

            builder.Property(x => x.Gender)
                .HasColumnName("gender");

            builder.Property(x => x.BiologicalSex)
                .HasColumnName("biological_sex");

            builder.Property(x => x.BloodType)
                .HasColumnName("blood_type");

            builder.Property(x => x.BirthDate)
                .HasColumnName("birth_date");

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at");

            builder.Property(x => x.RemovedAt)
                .HasColumnName("removed_at");

            builder.HasIndex(x => x.CPF)
                .IsUnique();

            builder.HasIndex(x => x.FullName);
            builder.HasIndex(x => x.RemovedAt);
        }
    }
} 