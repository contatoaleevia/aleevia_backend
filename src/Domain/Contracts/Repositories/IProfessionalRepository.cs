using CrossCutting.Repositories;
using Domain.Entities.Professionals;

namespace Domain.Contracts.Repositories;

public interface IProfessionalRepository : IRepository<Professional>
{
    Task<Professional?> GetByCpfToRegisterAsync(string cpf);
    Task<Professional?> GetByUserIdWithDetailsAsync(Guid userId);
    Task<Professional?> GetByManagerIdAsync(Guid managerId);
    Task CreateSpecialtyDetailAsync(ProfessionalSpecialtyDetail specialtyDetail, bool saveChanges = true);
    Task UpdateSpecialtyDetailsAsync(ProfessionalSpecialtyDetail specialtyDetail, bool saveChanges = true);
    Task CreateDocumentAsync(ProfessionalDocument document, bool saveChanges = true);
    Task UpdateProfessionalAddressAsync(ProfessionalAddress professionalAddress, bool saveChanges = true);
    Task CreateProfessionalAddressAsync(ProfessionalAddress newAddress, bool saveChanges = true);
}