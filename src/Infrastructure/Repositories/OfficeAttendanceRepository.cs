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
        return await context
            .Set<OfficeAttendance>()
            .Where(oa => oa.OfficeId == officeId && oa.Active)
            .Include(oa => oa.ServiceType)
            .AsNoTracking()
            .ToListAsync();
    }

    public new async Task<OfficeAttendance?> GetByIdAsync(Guid id)
    {
        return await context
            .Set<OfficeAttendance>()
            .Include(oa => oa.ServiceType)
            .Include(oa => oa.Office)
            .FirstOrDefaultAsync(oa => oa.Id == id);
    }

    public async Task<bool> ExistsByOfficeIdAndServiceTypeIdAsync(Guid officeId, Guid serviceTypeId)
    {
        return await context
            .Set<OfficeAttendance>()
            .AnyAsync(oa => oa.OfficeId == officeId && oa.ServiceTypeId == serviceTypeId && oa.Active);
    }
} 