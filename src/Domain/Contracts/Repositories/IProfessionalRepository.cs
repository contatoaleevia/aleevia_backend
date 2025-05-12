using CrossCutting.Repositories;
using Domain.Entities.Professionals;

namespace Domain.Contracts.Repositories;

public interface IProfessionalRepository : IRepository<Professional>
{
    Task<Professional?> GetByCpfToRegisterAsync(string cpf);
    Task CreateSpecialtyDetailAsync(ProfessionalSpecialtyDetail specialtyDetail);
    Task CreateDocumentAsync(ProfessionalDocument document);
}