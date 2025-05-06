using CrossCutting.Repositories;
using Domain.Entities.Offices;

namespace Domain.Contracts.Repositories;
public interface IOfficeAddressRepository : IRepository<OfficeAddress>
{
    Task<List<OfficeAddress>> GetOfficeAddress(Guid officeId);
}