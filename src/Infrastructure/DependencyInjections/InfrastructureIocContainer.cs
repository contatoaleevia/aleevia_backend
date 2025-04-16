using CrossCutting.DependencyInjections;
using Domain.Doctors.Contracts;
using Infrastructure.Contexts;
using Infrastructure.Doctors.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjections;

public static class InfrastructureIocContainer
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterApiDbContext(services, configuration);
        RegisterRepositories(services);
    }
    
    private static void RegisterApiDbContext(IServiceCollection services, IConfiguration configuration)
    {
       services.RegisterPostgresSql<ApiDbContext>(configuration);
    }
    
    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IDoctorRepository, DoctorRepository>();
    }
}