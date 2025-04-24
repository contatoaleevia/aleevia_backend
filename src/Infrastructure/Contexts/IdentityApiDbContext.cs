using Domain.Entities.Identities;
using Infrastructure.Configurations.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;


public class IdentityApiDbContext(DbContextOptions<IdentityApiDbContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public override DbSet<User> Users { get; set; }

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
    
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}   