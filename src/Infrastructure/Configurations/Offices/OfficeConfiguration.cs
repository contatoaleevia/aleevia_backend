using Domain.Entities.Offices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Offices;

public class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder.ToTable("office");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.OwnerId)
            .IsRequired()
            .HasColumnName("owner_id");
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("name")
            .HasMaxLength(100);

        builder.Property(x => x.Individual)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnName("individual");
        
        builder.OwnsOne(x => x.Cnpj, cnpj => 
        {
            cnpj.Property(x => x.Value)
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasColumnName("cnpj")
                .HasMaxLength(14);
        });
        
        builder.OwnsOne(x => x.Phone, phone => 
        {
            phone.Property(x => x.Value)
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasColumnName("phone")
                .HasMaxLength(15);
        });
        
        builder.OwnsOne(x => x.Whatsapp, whatsapp => 
        {
            whatsapp.Property(x => x.Value)
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasColumnName("whatsapp")
                .HasMaxLength(15);
        });
        
        builder.OwnsOne(x => x.Email, email => 
        {
            email.Property(x => x.Value)
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasColumnName("email")
                .HasMaxLength(100);
        });
        
        builder.OwnsOne(x => x.Site, site => 
        {
            site.Property(x => x.Value)
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasColumnName("site")
                .HasMaxLength(100);
        });
        
        builder.OwnsOne(x => x.Instagram, instagram => 
        {
            instagram.Property(x => x.Value)
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasColumnName("instagram")
                .HasMaxLength(100);
        });
        
        builder.OwnsOne(x => x.Logo, logo => 
        {
            logo.Property(x => x.Value)
                .IsRequired()
                .HasDefaultValue(string.Empty)
                .HasColumnName("logo")
                .HasMaxLength(100);
        });
        
        builder.HasOne(x => x.Owner)
            .WithMany()
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}