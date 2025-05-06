using CrossCutting.Repositories;
using Domain.Entities.Patients;

namespace Domain.Contracts.Repositories;

public interface IPatientRepository : IRepository<Patient>
{
    new Task<Patient?> GetByIdAsync(Guid id);
    Task<Patient?> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Patient>> GetAllAsync();
} 