using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.HealthCares;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class HealthCareRepository(ApiDbContext context) : Repository<HealthCare>(context), IHealthCareRepository
{
    public async Task<List<HealthCare>> GetByOfficeIdAsync(Guid officeId)
    {
        return await DbSet
            .AsNoTracking()
            .Where(x => x.OfficeId == officeId)
            .ToListAsync();
    }
}