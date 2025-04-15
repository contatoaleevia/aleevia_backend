using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjections;

public static class CrossCuttingIocContainer
{
    public static void AddCrossCuttingServices(this IServiceCollection services, IConfiguration configuration)
    {
    }
}