using CrossCutting.FileStorages;
using CrossCutting.FileStorages.Settings;
using CrossCutting.Identities;
using CrossCutting.Notifications;
using CrossCutting.Session;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjections;

public static class CrossCuttingIocContainer
{
    public static void AddCrossCuttingServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterConfigurations(services, configuration);
        RegisterServices(services);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<INotificationContext, NotificationContext>();
        services.AddScoped<IIdentityNotificationHandler, IdentityNotificationHandler>();
        services.AddScoped<IUserSession, UserSession>();
        services.AddScoped<IFileStorageS3, FileStorageS3>();
    }

    private static void RegisterConfigurations(IServiceCollection services, IConfiguration configuration)
    {
        var fileStorageSettings = FileStorageSettings.GetInstance(configuration);
        services.AddSingleton<IFileStorageSettings>(fileStorageSettings);
    }
}