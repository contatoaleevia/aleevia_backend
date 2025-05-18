using Domain.Entities.Addresses;
using Domain.Entities.Faqs;
using Domain.Entities.Identities;
using Domain.Entities.HealthcareProfessionals;
using Domain.Entities.IaChats;
using Domain.Entities.OfficeAttendances;
using Domain.Entities.Offices;
using Domain.Entities.Patients;
using Domain.Entities.Professionals;
using Domain.Entities.ServiceTypes;
using Domain.Entities.HealthCares;
using Infrastructure.Configurations.Addresses;
using Infrastructure.Configurations.Faqs;
using Infrastructure.Configurations.HealthcareProfessionals;
using Infrastructure.Configurations.IaChats;
using Infrastructure.Configurations.Identities;
using Infrastructure.Configurations.OfficeAttendances;
using Infrastructure.Configurations.Offices;
using Infrastructure.Configurations.Patients;
using Infrastructure.Configurations.Professionals;
using Infrastructure.Configurations.ServiceTypes;
using Infrastructure.Configurations.HealthCares;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class ApiDbContext(DbContextOptions<ApiDbContext> options)
    : IdentityDbContext<
        User,
        Role,
        Guid,
        IdentityUserClaim<Guid>,
        UserRole,
        IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>,
        IdentityUserToken<Guid>>(options)
{
    public override DbSet<User> Users { get; set; }
    public override DbSet<Role> Roles { get; set; }
    public override DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<FaqPage> FaqPages { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<Speciality> Specialties { get; set; }
    public DbSet<SubSpecialty> SubSpecialties { get; set; }
    public DbSet<OfficeAttendance> OfficeAttendances { get; set; }
    public DbSet<IaChat> IaChats { get; set; }
    public DbSet<IaMessage> IaMessages { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<OfficeAddress> OfficeAddresses { get; set; }
    public DbSet<Professional> Professionals { get; set; }
    public DbSet<OfficesProfessional> OfficesProfessionals { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientLead> PatientLeads { get; set; }
    public DbSet<HealthCare> HealthCares { get; set; }
    public DbSet<IaChatRating> IaChatRatings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("public");

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
        builder.ApplyConfiguration(new OfficeAttendanceConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new UserRoleConfiguration());
        builder.ApplyConfiguration(new IaChatConfiguration());
        builder.ApplyConfiguration(new IaMessageConfiguration());
        builder.ApplyConfiguration(new OfficeAddressConfiguration());
        builder.ApplyConfiguration(new ProfessionalConfiguration());
        builder.ApplyConfiguration(new OfficesProfessionalsConfiguration());
        builder.ApplyConfiguration(new PatientConfiguration());
        builder.ApplyConfiguration(new PatientLeadConfiguration());
        builder.ApplyConfiguration(new FaqPageConfiguration());
        builder.ApplyConfiguration(new ProfessionalDocumentConfiguration());
        builder.ApplyConfiguration(new ProfessionalSpecialtyDetailConfiguration());
        builder.ApplyConfiguration(new OfficeSpecialtyConfiguration());
        builder.ApplyConfiguration(new HealthCareConfiguration());
        builder.ApplyConfiguration(new IaChatRatingConfiguration());

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}