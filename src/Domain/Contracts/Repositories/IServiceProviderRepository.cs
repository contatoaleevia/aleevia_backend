using CrossCutting.Repositories;
using Domain.Entities.ServiceProviders;

namespace Domain.Contracts.Repositories;

public interface IServiceProviderRepository : IRepository<ServiceProvider>
{
    Task<List<ServiceProvider>> GetAllAsync(Guid officeId);
    Task<List<ServiceProvider>> SearchAsync(Guid officeId, string? cnpj = null, string? name = null);
} 