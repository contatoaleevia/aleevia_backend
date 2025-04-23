using CrossCutting.DependencyInjections;
using Infrastructure.Contexts;
using Infrastructure.Initialize;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjections;

public static class InfrastructureIocContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterApiDbContext(services, configuration);
        RegisterRepositories(services);
        services.AddIdentityConfiguration(configuration);
    }
    
    private static void RegisterApiDbContext(IServiceCollection services, IConfiguration configuration)
    {
       services.RegisterPostgresSql<ApiDbContext>(configuration);
    }
    
    private static void RegisterRepositories(IServiceCollection services)
    {
    }
}