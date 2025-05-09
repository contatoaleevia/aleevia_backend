using CrossCutting.Repositories;
using Domain.Entities.Patients;
using Domain.Contracts.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PatientRepository(ApiDbContext context) 
    : Repository<Patient>(context), IPatientRepository
{
    public async Task<Patient?> GetByUserIdAsync(Guid userId)
    {
        return await DbSet
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.UserId == userId && p.RemovedAt == null);
    }

    public new async Task<Patient?> GetByIdAsync(Guid id)
    {
        return await DbSet
            .Include(p => p.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id && p.RemovedAt == null);
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await DbSet
            .Include(p => p.User)
            .Where(p => p.RemovedAt == null)
            .AsNoTracking()
            .ToListAsync();
    }
} 