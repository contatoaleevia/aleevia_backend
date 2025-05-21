using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities.OfficeAttendances;

namespace Infrastructure.Configurations.OfficeAttendances;

public class OfficeAttendanceConfiguration : IEntityTypeConfiguration<OfficeAttendance>
{
    public void Configure(EntityTypeBuilder<OfficeAttendance> builder)
    {
        builder.ToTable("office_attendance");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired();

        builder.Property(x => x.OfficeId)
            .HasColumnName("office_id")
            .IsRequired();

        builder.Property(x => x.ServiceTypeId)
            .HasColumnName("service_type_id")
            .IsRequired();

        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(x => x.Duration)
            .HasColumnName("duration")
            .IsRequired();

        builder.OwnsOne(x => x.Price, price =>
        {
            price.Property(p => p.ValueAsCents)
                .HasColumnName("price")
                .IsRequired();
        });

        builder.Property(x => x.Active)
            .HasColumnName("active")
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.HasOne(x => x.Office)
            .WithMany()
            .HasForeignKey(x => x.OfficeId);

        builder.HasOne(x => x.ServiceType)
            .WithMany()
            .HasForeignKey(x => x.ServiceTypeId);
    }
} 