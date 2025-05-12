using CrossCutting.Repositories;
using Domain.Entities.Offices;

namespace Domain.Contracts.Repositories;

public interface IOfficeRepository : IRepository<Office>
{
    Task<List<Office>> GetAllByOwnerIdAsync(Guid ownerId);
}
