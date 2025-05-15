using Domain.Entities.HealthCares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.HealthCares;
public class HealthCareConfiguration : IEntityTypeConfiguration<HealthCare>
{
    public void Configure(EntityTypeBuilder<HealthCare> builder)
    {
        builder.ToTable("healthcare");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasOne(x => x.Office)
            .WithMany(x => x.HealthCares)
            .HasForeignKey(x => x.OfficeId);

        builder.Property(x => x.OfficeId)
            .HasColumnName("office_id");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasMaxLength(100);

        builder.Property(x => x.AnsNumber)
            .HasColumnName("ans_number")
            .HasMaxLength(20);

        builder.Property(x => x.Registry)
            .HasColumnName("registry")
            .HasMaxLength(20);

        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasColumnName("is_active")
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");
    }
}