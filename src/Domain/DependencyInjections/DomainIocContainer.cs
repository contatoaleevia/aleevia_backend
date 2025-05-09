using Domain.Contracts.Services.RegisterProfessionals;
using Domain.Services.Professionals;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.DependencyInjections;

public static class DomainIocContainer
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IRegisterProfessional, RegisterProfessional>();
    }
}