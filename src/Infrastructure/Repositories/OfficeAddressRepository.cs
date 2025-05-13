using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class OfficeAddressRepository(ApiDbContext context) : Repository<OfficeAddress>(context), IOfficeAddressRepository
{
    public async Task<List<OfficeAddress>> GetOfficeAddress(Guid officeId)
    {
        return await DbSet
            .Where(x => x.OfficeId == officeId && x.IsActive)
            .Include(x => x.Address)
            .AsNoTracking()
            .ToListAsync();
    }
}