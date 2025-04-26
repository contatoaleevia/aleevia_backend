using Domain.Entities.Identities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Identities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id");
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");
     
        builder.OwnsOne(x => x.Cpf, document =>
        {
            document.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("cpf");
        });
        
        builder.OwnsOne(x => x.Cnpj, document =>
        {
            document.Property(x => x.Value)
                .IsRequired(false)
                .HasMaxLength(14)
                .HasColumnName("cnpj");
        }).Navigation(x => x.Cnpj).IsRequired(false);

        builder.OwnsOne(x => x.UserType, userType =>
        {
            userType.Property(x => x.UserTypeId)
                .IsRequired()
                .HasColumnName("type");
        });
        
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
        
        builder.Property(x => x.UpdatedAt)
            .IsRequired(false)
            .HasColumnName("updated_at");
        
        builder.Property(x => x.DeletedAt)
            .IsRequired(false)
            .HasColumnName("deleted_at");
        
        builder.Property(x => x.Active)
            .IsRequired()
            .HasColumnName("active");

        builder.Property(x => x.UserName)
            .HasMaxLength(100)
            .IsRequired(false)
            .HasColumnName("user_name");
        
        builder.Property(x => x.Email)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("email");

        builder.Property(x => x.EmailConfirmed)
            .IsRequired()
            .HasColumnName("email_confirmed");
        
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired()
            .HasColumnName("phone_number");
        
        builder.Property(x => x.PhoneNumberConfirmed)
            .IsRequired()
            .HasColumnName("phone_number_confirmed");

        builder.Property(x => x.TwoFactorEnabled)
            .HasColumnName("two_factor_enabled");
        
        builder.Property(x => x.LockoutEnabled)
            .HasColumnName("lockout_enabled");
        
        builder.Property(x => x.LockoutEnd)
            .IsRequired(false)
            .HasColumnName("lockout_end");
        
        builder.Property(x => x.AccessFailedCount)
            .HasColumnName("access_failed_count");
        
        builder.Property(x => x.NormalizedUserName)
            .HasColumnName("normalized_user_name");
        
        builder.Property(x => x.NormalizedEmail)
            .HasColumnName("normalized_email");
        
        builder.Property(x => x.ConcurrencyStamp)
            .HasColumnName("concurrency_stamp");
        
        builder.Property(x => x.SecurityStamp)
            .HasColumnName("security_stamp");
        
        builder.Property(x => x.PasswordHash)
            .HasColumnName("password_hash");

        builder.HasMany(x => x.UserRoles)
            .WithOne()
            .HasForeignKey(x => x.UserId);
    }
}