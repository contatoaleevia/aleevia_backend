using Domain.Entities.Patients;

namespace Domain.Contracts.Repositories;

public interface IPatientLeadRepository
{
    Task<PatientLead?> GetByIdAsync(Guid id);
    Task<PatientLead?> GetByCpfOrEmailAsync(string cpf, string email);
    Task<IEnumerable<PatientLead>> GetAllAsync();
    Task<PatientLead> CreateAsync(PatientLead patientLead);
} 