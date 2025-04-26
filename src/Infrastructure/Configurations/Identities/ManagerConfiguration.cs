using Domain.Entities.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Identities;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
    public void Configure(EntityTypeBuilder<Manager> builder)
    {
        builder.ToTable("manager");
        
        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Id)
            .IsRequired()
            .HasColumnName("id");

        builder.Property(x => x.CorporateName)
            .IsRequired(false)
            .HasMaxLength(100)
            .HasColumnName("corporate_name");

        builder.OwnsOne(x => x.ManagerType, type =>
        {
            type.Property(x => x.TypeId)
                .IsRequired()
                .HasColumnName("type");
        });
        
        builder.Property(x => x.UserId)
            .HasColumnName("user_id");
        
        builder.HasOne(x => x.User)
            .WithOne(x => x.Manager)
            .HasForeignKey<Manager>(x => x.UserId);
    }
}