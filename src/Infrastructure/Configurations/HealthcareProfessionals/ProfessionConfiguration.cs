using Domain.Entities.HealthcareProfessionals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.HealthcareProfessionals;

public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
{
    public void Configure(EntityTypeBuilder<Profession> builder)
    {
        builder.ToTable("professions");

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

        builder.HasMany(x => x.Specialties)
            .WithOne(x => x.Profession)
            .HasForeignKey(x => x.ProfessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 