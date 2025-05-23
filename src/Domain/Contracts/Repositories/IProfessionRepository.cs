using CrossCutting.Repositories;
using Domain.Entities.HealthcareProfessionals;

namespace Domain.Contracts.Repositories;

public interface IProfessionRepository : IRepository<Profession>
{
    Task<List<Profession>> GetAllActiveAsync();
    Task<Speciality?> GetSpecialityByIdAsync(Guid id);
    Task<SubSpecialty?> GetSubSpecialityByIdAsync(Guid? id);
}