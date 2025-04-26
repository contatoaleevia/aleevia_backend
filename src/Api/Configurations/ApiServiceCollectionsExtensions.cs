using Api.Filters;
using Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace Api.Configurations;

public static class ApiServiceCollectionsExtensions
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services
            .AddControllers(opt => 
                opt.Filters.Add(typeof(NotificationFilter)))
            .AddApplicationPart(ApplicationAssemblyRef.Assembly);
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aleevia API", Version = "v1" });
            c.OperationFilter<ApiKeyOperationFilter>();
            c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "API Key must be provided in header",
                Type = SecuritySchemeType.ApiKey,
                Name = "X-Api-Key",
                In = ParameterLocation.Header,
                Scheme = "ApiKeyScheme"
            });
        });
        
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