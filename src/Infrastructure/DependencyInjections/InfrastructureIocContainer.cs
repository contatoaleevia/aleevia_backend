using CrossCutting.DependencyInjections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjections;

public static class InfrastructureIocContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterApiDbContext(services, configuration);
    }
    
    private static void RegisterApiDbContext(IServiceCollection services, IConfiguration configuration)
    {
       services.RegisterPostgresSql<DbContext>(configuration);
    }
}