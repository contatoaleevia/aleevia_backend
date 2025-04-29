using Domain.Entities.HealthcareProfessionals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.HealthcareProfessionals;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        builder.ToTable("specialties");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(x => x.Active)
            .IsRequired()
            .HasColumnName("active");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(x => x.ProfessionId)
            .IsRequired()
            .HasColumnName("profession_id");

        builder.HasMany(x => x.SubSpecialties)
            .WithOne(x => x.Specialty)
            .HasForeignKey(x => x.SpecialtyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 