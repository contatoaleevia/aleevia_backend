using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjections;

public static class EmailServiceCollection
{
    public static IServiceCollection AddEmailServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(
            configuration.GetSection("EmailSettings"));

        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
} 