using CrossCutting.Identities;
using CrossCutting.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjections;

public static class CrossCuttingIocContainer
{
    public static void AddCrossCuttingServices(this IServiceCollection services)
    {
        services.AddScoped<INotificationContext, NotificationContext>();
        services.AddScoped<IIdentityNotificationHandler, IdentityNotificationHandler>();
    }
}