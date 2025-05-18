using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OfficeSpecialtyRepository(ApiDbContext context) : Repository<OfficeSpecialty>(context), IOfficeSpecialtyRepository
{
    public async Task<OfficeSpecialty?> GetByOfficeAndSpecialty(Guid officeId, Guid specialtyId)
    {
        return await DbSet
            .FirstOrDefaultAsync(
                os => os.OfficeId == officeId && 
                    os.SpecialtyId == specialtyId
            );
    }

    public async Task<OfficeSpecialty?> GetActiveByOfficeAndSpecialty(Guid officeId, Guid specialtyId)
    {
        return await DbSet
            .FirstOrDefaultAsync(
                os => os.OfficeId == officeId && 
                    os.SpecialtyId == specialtyId &&
                    os.IsActive
            );
    }

    public async Task<List<OfficeSpecialty>> GetByOfficeIdWithDetailsAsync(Guid officeId)
    {
        return await DbSet
            .Include(os => os.Speciality)
            .Where(os => os.OfficeId == officeId && os.IsActive)
            .ToListAsync();
    }
} 