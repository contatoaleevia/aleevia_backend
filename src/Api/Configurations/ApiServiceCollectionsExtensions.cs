using System.Reflection;
using Api.Filters;
using Application;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Api.Configurations;

public static class ApiServiceCollectionsExtensions
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services
            .AddControllers(opt =>
            {
                opt.Filters.Add(typeof(NotificationFilter));
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = new Dictionary<string, List<string>>();

                    foreach (var modelStateEntry in context.ModelState)
                    {
                        var errorMessages = modelStateEntry.Value?.Errors
                            .Select(error =>
                            {
                                if (error.ErrorMessage.Contains("JSON deserialization"))
                                {
                                    var match = Regex.Match(error.ErrorMessage, @"missing required properties, including the following: (.+)$");
                                    if (match.Success)
                                    {
                                        var fields = match.Groups[1].Value.Split(',')
                                            .Select(f => f.Trim())
                                            .Where(f => !string.IsNullOrEmpty(f));
                                        return $"Os seguintes campos são obrigatórios: {string.Join(", ", fields)}";
                                    }
                                    return "Campo obrigatório não foi enviado no corpo da requisição";
                                }
                                if (error.ErrorMessage.Contains("field is required"))
                                {
                                    var fieldName = modelStateEntry.Key.Replace("requestDto.", "");
                                    return $"O campo {fieldName} é obrigatório";
                                }
                                return error.ErrorMessage;
                            })
                            .ToList();

                        if (errorMessages != null && errorMessages.Count != 0)
                        {
                            var key = modelStateEntry.Key == "$" ? "Erro de Validação" : modelStateEntry.Key.Replace("requestDto.", "");
                            errors.Add(key, errorMessages);
                        }
                    }

                    return new BadRequestObjectResult(new
                    {
                        title = "Erro de Validação",
                        status = 400,
                        errors = errors,
                        traceId = context.HttpContext.TraceIdentifier
                    });
                };
            })
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