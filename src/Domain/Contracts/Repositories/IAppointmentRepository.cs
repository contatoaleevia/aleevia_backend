using CrossCutting.Repositories;
using Domain.Entities.Appointments;

namespace Domain.Contracts.Repositories;
public interface IAppointmentRepository : IRepository<Appointment>
{
    Task<Appointment?> GetAppointmentByAddress(Guid? addressId, DateTime appointmentDate);
}