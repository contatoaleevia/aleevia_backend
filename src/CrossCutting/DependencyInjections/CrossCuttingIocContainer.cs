using CrossCutting.FileStorages;
using CrossCutting.FileStorages.Settings;
using CrossCutting.Identities;
using CrossCutting.MinioFileStorages;
using CrossCutting.MinioFileStorages.Settings;
using CrossCutting.Notifications;
using CrossCutting.Session;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;

namespace CrossCutting.DependencyInjections;

public static class CrossCuttingIocContainer
{
    public static void AddCrossCuttingServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterServices(services);
        RegisterFileStorageS3(services, configuration);
        RegisterMinio(services, configuration);
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<INotificationContext, NotificationContext>();
        services.AddScoped<IIdentityNotificationHandler, IdentityNotificationHandler>();
        services.AddScoped<IUserSession, UserSession>();
    }

    private static void RegisterFileStorageS3(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IFileStorageSettings>(FileStorageSettings.GetInstance(configuration));
        services.AddScoped<IFileStorageS3, FileStorageS3>();
    }

    private static void RegisterMinio(IServiceCollection services, IConfiguration configuration)
    {
        var minioSettings = MinioSettings.GetInstance(configuration);
        services.AddSingleton<IMinioSettings>(minioSettings);
        services.AddMinio(configureClient => configureClient
            .WithEndpoint(minioSettings.Endpoint, 9000)
            .WithCredentials(minioSettings.AccessKey, minioSettings.SecretKey)
            .WithRegion("us-east-1")
            .WithSSL()
            .Build());
        services.AddScoped<IMinioService, MinioService>();
    }
}