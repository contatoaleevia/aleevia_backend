using CrossCutting.Repositories;
using Domain.Entities.Offices;

namespace Domain.Contracts.Repositories;

public interface IOfficesProfessionalsRepository : IRepository<OfficesProfessional>
{
    Task<List<OfficesProfessional>> GetByOfficeIdWithDetailsAsync(Guid officeId);
    Task<OfficesProfessional?> GetByOfficeAndProfessional(Guid officeId, Guid professionalId);
    Task<int> CountByOfficeIdAsync(Guid officeId);
}