using Domain.Entities.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Appointments;
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("appointment");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasOne(x => x.Patient)
            .WithMany()
            .HasForeignKey(x => x.PatientId);

        builder.HasOne(x => x.Professional)
            .WithMany()
            .HasForeignKey(x => x.ProfessionalId);

        builder.HasOne(x => x.AppointmentAddress)
            .WithMany()
            .HasForeignKey(x => x.AppointmentAddressId);

        builder.OwnsOne(x => x.AppointmentType, appointmentType =>
        {
            appointmentType.Property(x => x.AppointmentTypeEnum)
                .IsRequired()
                .HasColumnName("appointment_type");
        });

        builder.Property(x => x.Price)
            .IsRequired()
            .HasColumnName("price")
            .HasPrecision(10, 2);

        builder.Property(x => x.Date)
            .IsRequired()
            .HasColumnName("date")
            .HasColumnType("timestamp");

        builder.OwnsOne(x => x.Status, status =>
        {
            status.Property(x => x.AppointmentStatusEnum)
                .IsRequired()
                .HasColumnName("appointment_status");
        });

        builder.HasOne(x => x.Patient)
            .WithMany()
            .HasForeignKey(x => x.PatientCalendarEventId);

        builder.HasOne(x => x.Professional)
            .WithMany()
            .HasForeignKey(x => x.ProfessionalCalendarEventId);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .IsRequired(false)
            .HasColumnName("updated_at");

        builder.Property(x => x.DeletedAt)
            .IsRequired(false)
            .HasColumnName("deleted_at");
    }
}