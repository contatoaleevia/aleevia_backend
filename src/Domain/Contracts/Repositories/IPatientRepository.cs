using Domain.Entities.Patients;

namespace Domain.Contracts.Repositories;

public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(Guid id);
    Task<Patient?> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task<Patient> CreateAsync(Patient patient);
} 