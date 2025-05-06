using CrossCutting.Repositories;
using Domain.Entities.Patients;

namespace Domain.Contracts.Repositories;

public interface IPatientLeadRepository : IRepository<PatientLead>
{
    new Task<PatientLead?> GetByIdAsync(Guid id);
    Task<PatientLead?> GetByCpfOrEmailAsync(string cpf, string email);
    Task<IEnumerable<PatientLead>> GetAllAsync();
} 