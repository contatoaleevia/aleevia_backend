using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OfficesProfessionalsRepository(ApiDbContext context) : Repository<OfficesProfessional>(context), IOfficesProfessionalsRepository
{

    public async Task<List<OfficesProfessional>> GetByOfficeIdWithDetailsAsync(Guid officeId)
    {
        return await DbSet
            .Include(op => op.Professional)
            .ThenInclude(p => p.SpecialtyDetails)
            .Where(op => op.OfficeId == officeId && op.IsActive)
            .AsNoTracking()
            .ToListAsync();
    }
}