using Domain.Entities.HealthcareProfessionals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.HealthcareProfessionals;

public class SubSpecialtyConfiguration : IEntityTypeConfiguration<SubSpecialty>
{
    public void Configure(EntityTypeBuilder<SubSpecialty> builder)
    {
        builder.ToTable("sub_specialties");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Active)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.SpecialtyId)
            .IsRequired();
    }
} 