using Domain.Entities.Faqs;
using Domain.Entities.Identities;
using Domain.Entities.IaChats;
using Infrastructure.Configurations.Faqs;
using Domain.Entities.HealthcareProfessionals;
using Infrastructure.Configurations;
using Infrastructure.Configurations.Identities;
using Infrastructure.Configurations.Offices;
using Infrastructure.Configurations.ServiceTypes;
using Infrastructure.Configurations.HealthcareProfessionals;
using Infrastructure.Configurations.IaChats;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.ServiceTypes;
using Infrastructure.Configurations.Addresses;

namespace Infrastructure.Contexts;

public class ApiDbContext(DbContextOptions<ApiDbContext> options)
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public override DbSet<User> Users { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<SubSpecialty> SubSpecialties { get; set; }
    public DbSet<IaChat> IaChats { get; set; }
    public DbSet<IaMessage> IaMessages { get; set; }

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
        builder.ApplyConfiguration(new FaqConfiguration());

        builder.ApplyConfiguration(new ManagerConfiguration());
        builder.ApplyConfiguration(new AddressesConfiguration());
        builder.ApplyConfiguration(new OfficeConfiguration());
        builder.ApplyConfiguration(new ServiceTypeConfiguration());
        builder.ApplyConfiguration(new ProfessionConfiguration());
        builder.ApplyConfiguration(new SpecialtyConfiguration());
        builder.ApplyConfiguration(new SubSpecialtyConfiguration());
        builder.ApplyConfiguration(new IaChatConfiguration());
        builder.ApplyConfiguration(new IaMessageConfiguration());
    
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}   