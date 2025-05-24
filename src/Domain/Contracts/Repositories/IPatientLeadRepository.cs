using CrossCutting.Repositories;
using Domain.Entities.Patients;

namespace Domain.Contracts.Repositories;

public interface IPatientLeadRepository : IRepository<PatientLead>
{
    Task<PatientLead?> GetByCpfOrEmailAsync(string cpf, string email);
} 