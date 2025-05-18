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
        
        builder.Property(pa => pa.Id)
            .IsRequired()
            .HasColumnName("id");
        
        builder.Property(pa => pa.ProfessionalId)
            .IsRequired()
            .HasColumnName("professional_id");
            
        builder.Property(pa => pa.AddressId)
            .IsRequired()
            .HasColumnName("address_id");
            
        builder.HasOne(pa => pa.Address)
            .WithMany()
            .HasForeignKey(pa => pa.AddressId)
            .OnDelete(DeleteBehavior.NoAction);
            
        builder.HasOne(pa => pa.Professional)
            .WithMany(p => p.Addresses)
            .HasForeignKey(pa => pa.ProfessionalId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
