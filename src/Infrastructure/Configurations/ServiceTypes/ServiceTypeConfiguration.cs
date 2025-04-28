using Domain.Entities.ServiceTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.ServiceTypes;

public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
{
    public void Configure(EntityTypeBuilder<ServiceType> builder)
    {
        builder.ToTable("service_type");

        builder.Property(st => st.Id)
            .HasColumnName("id");

        builder.Property(st => st.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(st => st.Description)
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(st => st.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(st => st.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(st => st.Active)
            .HasColumnName("active")
            .IsRequired();
    }
} 