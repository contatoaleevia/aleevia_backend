using System.Text;
using CrossCutting.DependencyInjections;
using CrossCutting.Identities;
using Domain.Entities.Identities;
using Infrastructure.Contexts;
using Infrastructure.Helpers.ApiSettings.Settings;
using Infrastructure.Helpers.TokenObtainer.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Initialize;

public static class IdentityIocContainer
{
    public static void AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPostgresSql<IdentityApiDbContext>(configuration);

        services.AddDefaultIdentity<User>(options =>
            {
                options.Password = new PasswordOptions
                {
                    RequireDigit = true,
                    RequiredLength = 8,
                    RequireLowercase = true,
                    RequireUppercase = true,
                    RequireNonAlphanumeric = true
                };

                options.SignIn.RequireConfirmedEmail = true;
            }).AddDefaultTokenProviders()
            .AddErrorDescriber<IdentityErrorExtension>()
            .AddEntityFrameworkStores<IdentityApiDbContext>();

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
}