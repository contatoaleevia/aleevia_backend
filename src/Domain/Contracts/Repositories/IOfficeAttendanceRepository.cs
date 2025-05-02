using CrossCutting.Repositories;
using Domain.Entities.OfficeAttendances;

namespace Domain.Contracts.Repositories;

public interface IOfficeAttendanceRepository : IRepository<OfficeAttendance>
{
    Task<List<OfficeAttendance>> GetAllByOfficeIdAsync(Guid officeId);
    new Task<OfficeAttendance?> GetByIdAsync(Guid id);
    Task<bool> ExistsByOfficeIdAndServiceTypeIdAsync(Guid officeId, Guid serviceTypeId);
} 