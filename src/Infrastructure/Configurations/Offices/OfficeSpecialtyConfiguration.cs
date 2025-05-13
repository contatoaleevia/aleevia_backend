using Domain.Entities.Offices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Offices;

public class OfficeSpecialtyConfiguration : IEntityTypeConfiguration<OfficeSpecialty>
{
    public void Configure(EntityTypeBuilder<OfficeSpecialty> builder)
    {
        builder.ToTable("office_specialty");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.OfficeId)
            .IsRequired()
            .HasColumnName("office_id");

        builder.Property(x => x.SpecialtyId)
            .IsRequired()
            .HasColumnName("specialty_id");

        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasColumnName("is_active");

        builder.HasOne(x => x.Office)
            .WithMany(o => o.Specialties)
            .HasForeignKey(x => x.OfficeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Specialty)
            .WithMany()
            .HasForeignKey(x => x.SpecialtyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.OfficeId, x.SpecialtyId })
            .IsUnique();
    }
} 