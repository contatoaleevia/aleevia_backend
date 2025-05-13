using CrossCutting.Repositories;
using Domain.Entities.Offices;

namespace Domain.Contracts.Repositories;

public interface IOfficeSpecialtyRepository : IRepository<OfficeSpecialty>
{
    Task<OfficeSpecialty?> GetByOfficeAndSpecialty(Guid officeId, Guid specialtyId);
} 