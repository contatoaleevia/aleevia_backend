using Application.Helpers;
using Application.Services;
using Application.Services.Managers;
using Application.Services.Offices;
using Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjections;

public static class ApplicationIocContainer
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IGenerateJwtTokenHelper, GenerateJwtTokenHelper>();
        services.AddScoped<IManagerService, ManagerService>();
        services.AddScoped<IOfficeService, IOfficeService>();
    }
}