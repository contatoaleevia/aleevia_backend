using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Offices;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OfficeRepository(ApiDbContext context) : Repository<Office>(context), IOfficeRepository
{
    public async Task<Office?> GetByIdWithDetailsAsync(Guid id)
    {
        return await DbSet
            .Include(x => x.Addresses)
                .ThenInclude(x => x.Address)
            .Include(x => x.Professionals)
                .ThenInclude(x => x.Professional)
                    .ThenInclude(x => x.SpecialtyDetails)
                        .ThenInclude(x => x.Speciality)
            .Include(x => x.Professionals)
                .ThenInclude(x => x.Professional)
                    .ThenInclude(x => x.SpecialtyDetails)
                        .ThenInclude(x => x.Profession)
            .Include(x => x.Professionals)
                .ThenInclude(x => x.Professional)
                    .ThenInclude(x => x.SpecialtyDetails)
                        .ThenInclude(x => x.Subspeciality)
            .Include(x => x.Professionals)
                .ThenInclude(x => x.Professional)
                    .ThenInclude(x => x.Documents)
            .Include(x => x.Specialties.Where(s => s.IsActive))
                .ThenInclude(x => x.Specialty)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Office>> GetAllByOwnerIdWithDetailsAsync(Guid ownerId)
    {
        return await DbSet
            .Include(x => x.Addresses)
                .ThenInclude(x => x.Address)
            .Include(x => x.Specialties.Where(s => s.IsActive))
                .ThenInclude(x => x.Specialty)
            .Where(x => x.OwnerId == ownerId)
            .AsNoTracking()
            .ToListAsync();
    }
}