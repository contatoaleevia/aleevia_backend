using Domain.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Addresses;
public class AddressesConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");
        
        builder.Property(x => x.SourceId)
            .HasColumnName("source_id")
            .IsRequired(false);

        builder.HasOne(x => x.Source)
            .WithMany()
            .HasForeignKey(x => x.SourceId);

        builder.OwnsOne(x => x.SourceType, sourceType =>
        {
            sourceType.Property(x => x.UserTypeId)
                .HasColumnName("source_type")
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(x => x.Street)
            .HasMaxLength(200)
            .IsRequired()
            .HasColumnName("street");

        builder.Property(x => x.Neighborhood)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("neighborhood");

        builder.Property(x => x.Number)
            .HasMaxLength(10)
            .IsRequired()
            .HasColumnName("number");

        builder.Property(x => x.City)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("city");

        builder.Property(x => x.State)
            .HasMaxLength(50)
            .IsRequired()
            .HasColumnName("state");

        builder.Property(x => x.ZipCode)
            .HasMaxLength(10)
            .IsRequired()
            .HasColumnName("zip_code");

        builder.Property(x => x.Complement)
            .HasMaxLength(100)
            .HasColumnName("complement");

        builder.Property(x => x.Type)
            .HasMaxLength(50)
            .HasColumnName("type");

        builder.Property(x => x.Location)
            .HasMaxLength(50)
            .HasColumnName("location");

        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");
    }
}