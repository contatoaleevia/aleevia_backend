using CrossCutting.Repositories;
using Domain.Entities.Offices;

namespace Domain.Contracts.Repositories;

public interface IOfficeRepository : IRepository<Office>
{
    Task<Office?> GetByIdWithDetailsAsync(Guid id);
    Task<List<Office>> GetAllByOwnerIdWithDetailsAsync(Guid ownerId);
}
