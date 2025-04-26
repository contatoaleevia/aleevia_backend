using Domain.Entities.Identities;
using Infrastructure.Configurations.Identities;
using Infrastructure.Configurations.ServiceTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.ServiceTypes;

namespace Infrastructure.Contexts;

public class ApiDbContext(DbContextOptions<ApiDbContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public override DbSet<User> Users { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("public");
        
        builder.Entity<IdentityRole<Guid>>().ToTable("identity_role");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("identity_user_role");
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("identity_user_claim");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("identity_user_login");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("identity_role_claim");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("identity_user_token");

        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new ManagerConfiguration());
        builder.ApplyConfiguration(new ServiceTypeConfiguration());
    
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}   