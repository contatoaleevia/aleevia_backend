using System.Reflection;
using Api.Filters;
using Application;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;

namespace Api.Configurations;

public static class ApiServiceCollectionsExtensions
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.Configure<FormOptions>(x =>
        {
            x.MultipartHeadersLengthLimit = int.MaxValue;
            x.MultipartBoundaryLengthLimit = int.MaxValue;
            x.MultipartBodyLengthLimit = long.MaxValue;
            x.ValueLengthLimit = int.MaxValue;
            x.BufferBodyLengthLimit = long.MaxValue;
            x.MemoryBufferThreshold = int.MaxValue;
        });
        
        services.Configure<KestrelServerOptions>(option =>
        {
            option.Limits.MaxRequestBodySize = long.MaxValue;
        });
        
        services
            .AddControllers(opt =>
                opt.Filters.Add(typeof(NotificationFilter)))
            .AddApplicationPart(ApplicationAssemblyRef.Assembly);

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aleevia API", Version = "v1" });

            var apiXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
            c.IncludeXmlComments(apiXmlPath);

            c.OperationFilter<ApiKeyOperationFilter>();
            c.OperationFilter<AuthorizeCheckOperationFilter>();

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Baerer token deve ser fornecido no seu header",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    []
                }
            });
        });
    }
}