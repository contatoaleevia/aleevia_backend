using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.OfficeAttendances;

namespace Infrastructure.Configurations.OfficeAttendances;

public class OfficeAttendanceConfiguration : IEntityTypeConfiguration<OfficeAttendance>
{
    public void Configure(EntityTypeBuilder<OfficeAttendance> builder)
    {
        builder.ToTable("office_attendance");

        builder.Property(oa => oa.Id)
            .HasColumnName("id");

        builder.Property(oa => oa.OfficeId)
            .HasColumnName("office_id")
            .IsRequired();

        builder.Property(oa => oa.ServiceTypeId)
            .HasColumnName("service_type_id")
            .IsRequired();

        builder.Property(oa => oa.Title)
            .HasColumnName("title")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(oa => oa.Description)
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(oa => oa.Price)
            .HasColumnName("price")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(oa => oa.Active)
            .HasColumnName("active")
            .IsRequired();

        builder.Property(oa => oa.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(oa => oa.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne(oa => oa.Office)
            .WithMany()
            .HasForeignKey(oa => oa.OfficeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(oa => oa.ServiceType)
            .WithMany()
            .HasForeignKey(oa => oa.ServiceTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 