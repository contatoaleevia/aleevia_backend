using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OfficeRepository(ApiDbContext context) : Repository<Office>(context), IOfficeRepository
{
    public async Task<List<Office>> GetAllByOwnerIdAsync(Guid ownerId)
    {
        return await DbSet
            .Where(x => x.OwnerId == ownerId)
            .AsNoTracking()
            .ToListAsync();
    }
}