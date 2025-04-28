using Application.Helpers;
using Application.Services.Faqs;
using Application.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjections;

public static class ApplicationIocContainer
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFaqService, FaqService>();

        services.AddScoped<GenerateJwtTokenHelper>();
    }
}