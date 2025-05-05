using CrossCutting.Repositories;
using Domain.Entities.Patients;
using Domain.Contracts.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PatientLeadRepository(ApiDbContext context) 
    : Repository<PatientLead>(context), IPatientLeadRepository
{
    public async Task<PatientLead?> GetByCpfOrEmailAsync(string cpf, string email)
    {
        return await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Cpf.Value == cpf || p.Email == email && p.RemovedAt == null);
    }


    public new async Task<PatientLead?> GetByIdAsync(Guid id)
    {
        return await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id && p.RemovedAt == null);
    }

    public async Task<IEnumerable<PatientLead>> GetAllAsync()
    {
        return await DbSet
            .Where(p => p.RemovedAt == null)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<PatientLead> CreateAsync(PatientLead patientLead)
    {
        return base.CreateAsync(patientLead);
    }
} 