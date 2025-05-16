using System.Text;
using CrossCutting.Databases;
using CrossCutting.Identities;
using Domain.Contracts.Repositories;
using Domain.Entities.Identities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.Contexts;
using Infrastructure.Helpers.ApiSettings.Settings;
using Infrastructure.Helpers.TokenObtainer.Settings;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.DependencyInjections;

public static class InfrastructureIocContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterApiDbContext(services, configuration);
        RegisterRepositories(services);
        RegisterIdentityConfiguration(services, configuration);
        RegisterEmailServices(services, configuration);
    }
    
    private static void RegisterApiDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connection = SqlConnectionDatabaseSettings.GetInstance(configuration);
        services.AddDbContext<ApiDbContext>(options =>
            options.UseNpgsql(connection.DefaultConnection));
    }
    
    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IManagerRepository, ManagerRepository>();
        services.AddScoped<IOfficeRepository, OfficeRepository>();
        services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
        services.AddScoped<IFaqRepository, FaqRepository>();
        services.AddScoped<IFaqPageRepository, FaqPageRepository>();
        services.AddScoped<IProfessionRepository, ProfessionRepository>();
        services.AddScoped<IOfficeAttendanceRepository, OfficeAttendanceRepository>();
        services.AddScoped<IIaChatRepository, IaChatRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
        services.AddScoped<IOfficesProfessionalsRepository, OfficesProfessionalsRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IPatientLeadRepository, PatientLeadRepository>();
        services.AddScoped<IOfficeAddressRepository, OfficeAddressRepository>();
        services.AddScoped<IOfficeSpecialtyRepository, OfficeSpecialtyRepository>();
        services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
        services.AddScoped<IHealthCareRepository, HealthCareRepository>();
        services.AddScoped<IIaChatRatingRepository, IaChatRatingRepository>();
    }
    
    private static void RegisterIdentityConfiguration(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDefaultIdentity<User>(options =>
            {
                options.Password = new PasswordOptions
                {
                    RequireDigit = false,
                    RequiredLength = 6,
                    RequireLowercase = false,
                    RequireUppercase = false,
                    RequireNonAlphanumeric = false
                };

                options.SignIn.RequireConfirmedEmail = true;
                
                options.Lockout.AllowedForNewUsers = false;
                
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            }).AddDefaultTokenProviders()
            .AddRoles<Role>()
            .AddUserStore<UserStore<User, Role, ApiDbContext, Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, IdentityUserToken<Guid>, IdentityRoleClaim<Guid>>>()
            .AddErrorDescriber<IdentityErrorExtension>()
            .AddEntityFrameworkStores<ApiDbContext>();

        var tokenSettings = TokenObtainHelperSettings.GetInstance(configuration);
        var apiSettings = ApiSettingsHelper.GetInstance(configuration);
        var key = Encoding.ASCII.GetBytes(tokenSettings.Secret);
        
        services.AddAuthentication(opts =>
        {
            opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opts =>
        {
            opts.RequireHttpsMetadata = true;
            opts.SaveToken = true;
            opts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = apiSettings.ValidIn,
                ValidIssuer = apiSettings.Issuer
            };
        });
    }

    private static void RegisterEmailServices(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddScoped<IEmailService, EmailService>();
    }
}