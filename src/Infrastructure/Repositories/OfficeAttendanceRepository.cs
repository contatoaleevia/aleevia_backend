using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.OfficeAttendances;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OfficeAttendanceRepository(ApiDbContext context) 
    : Repository<OfficeAttendance>(context), IOfficeAttendanceRepository
{

    public async Task<List<OfficeAttendance>> GetAllByOfficeIdAsync(Guid officeId)
    {
        return await DbSet
            .Where(oa => oa.OfficeId == officeId)
            .Include(oa => oa.ServiceType)
            .AsNoTracking()
            .ToListAsync();
    }

    public new async Task<OfficeAttendance?> GetByIdAsync(Guid id)
    {
        return await DbSet
            .Include(oa => oa.ServiceType)
            .Include(oa => oa.Office)
            .AsNoTracking()
            .FirstOrDefaultAsync(oa => oa.Id == id);
    }

    public async Task<int> CountByOfficeIdAsync(Guid officeId)
    {
        return await DbSet
            .Where(oa => oa.OfficeId == officeId && oa.Active)
            .CountAsync();
    }
} 