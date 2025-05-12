using CrossCutting.Repositories;
using Domain.Entities.Professionals;

namespace Domain.Contracts.Repositories;

public interface IProfessionalRepository : IRepository<Professional>
{
    Task<Professional?> GetByCpfToRegisterAsync(string cpf);
    Task<Professional?> GetByUserIdWithDetailsAsync(Guid userId);
    Task<Professional?> GetByManagerIdAsync(Guid managerId);
    Task CreateSpecialtyDetailAsync(ProfessionalSpecialtyDetail specialtyDetail);
    Task CreateDocumentAsync(ProfessionalDocument document);
}