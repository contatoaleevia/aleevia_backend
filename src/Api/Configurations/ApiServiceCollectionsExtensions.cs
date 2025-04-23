using Microsoft.AspNetCore.Identity;

namespace Api.Configurations;

public static class ApiServiceCollectionsExtensions
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                corsPolicyBuilder =>
                {
                    corsPolicyBuilder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
    }
}