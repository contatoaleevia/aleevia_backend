using Domain.Entities;
using Domain.Entities.Addresses;
using Domain.Entities.Appointments;
using Domain.Entities.Associations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Associations;
public class AppointmentAddressConfiguration : IEntityTypeConfiguration<AppointmentAddress>
{
    public void Configure(EntityTypeBuilder<AppointmentAddress> builder)
    {
        builder.ToTable("appointment_address");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.HasOne<Address>()
            .WithMany()
            .HasForeignKey(x => x.AddressId)
            .IsRequired();

        builder.HasOne<Appointment>()
            .WithMany()
            .HasForeignKey(x => x.AppointmentId)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(x => x.DeletedAt)
            .HasColumnName("deleted_at");
    }
}