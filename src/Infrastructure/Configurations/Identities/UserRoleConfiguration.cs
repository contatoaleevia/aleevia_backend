using Domain.Entities.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Identities;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("identity_user_role");
        
        builder.HasKey(x => new { x.UserId, x.RoleId });
        
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnName("user_id");
        
        builder.Property(x => x.RoleId)
            .IsRequired()
            .HasColumnName("role_id");
        
        builder.HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId);
    }
}