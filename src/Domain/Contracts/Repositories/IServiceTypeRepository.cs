using CrossCutting.Repositories;
using Domain.Entities.ServiceTypes;

namespace Domain.Contracts.Repositories;

public interface IServiceTypeRepository : IRepository<ServiceType>
{
    Task<List<ServiceType>> GetAllAsync();
}
