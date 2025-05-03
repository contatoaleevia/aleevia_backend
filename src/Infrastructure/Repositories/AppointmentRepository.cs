using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Appointments;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AppointmentRepository(ApiDbContext context) : Repository<Appointment>(context), IAppointmentRepository
    {
        public async Task<Appointment?> GetAppointmentByAddress(Guid? addressId, DateTime appointmentDate)
        => await DbSet.AsNoTracking()
                      .FirstOrDefaultAsync(x => x.AppointmentAddressId == addressId && 
                                                x.Date == appointmentDate &&
                                                x.DeletedAt != null);
    }
}