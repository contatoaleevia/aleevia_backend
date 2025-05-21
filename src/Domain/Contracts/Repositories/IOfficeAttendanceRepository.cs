using CrossCutting.Repositories;
using Domain.Entities.OfficeAttendances;
using Domain.Entities.Offices;

namespace Domain.Contracts.Repositories;

public interface IOfficeAttendanceRepository : IRepository<OfficeAttendance>
{
    Task<List<OfficeAttendance>> GetAllByOfficeIdAsync(Guid officeId);
    new Task<OfficeAttendance?> GetByIdAsync(Guid id);
    Task<int> CountByOfficeIdAsync(Guid officeId);
} 