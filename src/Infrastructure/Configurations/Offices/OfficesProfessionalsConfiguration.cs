using Domain.Entities.Offices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Offices;
public class OfficesProfessionalsConfiguration : IEntityTypeConfiguration<OfficesProfessionals>
{
    public void Configure(EntityTypeBuilder<OfficesProfessionals> builder)
    {
        builder.ToTable("offices_professionals");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Professional)
            .WithMany()
            .HasForeignKey(x => x.ProfessionalId);
        
        builder.HasOne(x => x.Office)
            .WithMany()
            .HasForeignKey(x => x.OfficeId);

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(x => x.DeletedAt)
            .HasColumnName("deleted_at");
    }
}