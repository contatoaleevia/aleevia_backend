using Domain.Entities.ServiceProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.ServiceProviders;

public class ServiceProviderConfiguration : IEntityTypeConfiguration<ServiceProvider>
{
    public void Configure(EntityTypeBuilder<ServiceProvider> builder)
    {
        builder.ToTable("service_providers");

        builder.HasKey(sp => sp.Id);

        builder.OwnsOne(x => x.Cnpj, cnpj => 
        {
            cnpj.Property(x => x.Value)
                .HasColumnName("cnpj")
                .IsRequired()
                .HasMaxLength(14);
        });

        builder.Property(sp => sp.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(sp => sp.CorporateName)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("corporate_name");

        builder.Property(sp => sp.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasColumnName("is_active");

        builder.Property(sp => sp.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(sp => sp.UpdatedAt)
            .IsRequired(false)
            .HasColumnName("updated_at");

        builder.Property(sp => sp.OfficeId)
            .IsRequired()
            .HasColumnName("office_id");

        builder.HasOne(sp => sp.Office)
            .WithMany()
            .HasForeignKey(sp => sp.OfficeId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasIndex(sp => sp.Name);
    }
} 