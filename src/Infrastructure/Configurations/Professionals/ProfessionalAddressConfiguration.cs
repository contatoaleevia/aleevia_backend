using Domain.Entities.Professionals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Professionals;

public class ProfessionalAddressConfiguration : IEntityTypeConfiguration<ProfessionalAddress>
{
    public void Configure(EntityTypeBuilder<ProfessionalAddress> builder)
    {
        builder.ToTable("professional_address");
        
        builder.HasKey(pa => pa.Id);
        
        builder.Property(pa => pa.ProfessionalId)
            .IsRequired();
            
        builder.Property(pa => pa.AddressId);
            
        builder.HasOne(pa => pa.Address)
            .WithMany()
            .HasForeignKey(pa => pa.AddressId)
            .OnDelete(DeleteBehavior.NoAction);
            
        // Relationship with Professional
        builder.HasOne(pa => pa.Professional)
            .WithMany(p => p.Addresses)
            .HasForeignKey(pa => pa.ProfessionalId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
