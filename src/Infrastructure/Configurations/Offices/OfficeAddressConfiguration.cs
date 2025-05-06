using Domain.Entities.Offices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Offices;

public class OfficeAddressConfiguration : IEntityTypeConfiguration<OfficeAddress>
{
    public void Configure(EntityTypeBuilder<OfficeAddress> builder)
    {
        builder.ToTable("office_address");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");
        
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasColumnName("is_active");
        
        builder.Property(x => x.AddressId)
            .IsRequired()
            .HasColumnName("address_id");
        
        builder.Property(x => x.OfficeId)
            .IsRequired()
            .HasColumnName("office_id");
        
        builder.HasOne(x => x.Address)
            .WithMany()
            .HasForeignKey(x => x.AddressId);
        
        builder.HasOne(x => x.Office)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.OfficeId);
        
        builder.HasIndex(x => new { x.AddressId, x.OfficeId })
            .IsUnique();
    }
}