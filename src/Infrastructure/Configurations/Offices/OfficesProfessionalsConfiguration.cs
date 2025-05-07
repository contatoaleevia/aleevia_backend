using Domain.Entities.Offices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Offices;
public class OfficesProfessionalsConfiguration : IEntityTypeConfiguration<OfficesProfessional>
{
    public void Configure(EntityTypeBuilder<OfficesProfessional> builder)
    {
        builder.ToTable("offices_professional");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Professional)
            .WithMany()
            .HasForeignKey(x => x.ProfessionalId);
        
        builder.Property(x => x.ProfessionalId)
            .IsRequired()
            .HasColumnName("professional_id");
        
        builder.HasOne(x => x.Office)
            .WithMany()
            .HasForeignKey(x => x.OfficeId);

        builder.Property(x => x.OfficeId)
            .IsRequired()
            .HasColumnName("office_id");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(x => x.DeletedAt)
            .HasColumnName("deleted_at");
        
        builder.Property(x => x.IsPublic)
            .IsRequired()
            .HasColumnName("is_public");
        
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasColumnName("is_active");
    }
}