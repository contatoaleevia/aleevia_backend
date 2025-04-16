using CrossCutting.Repositories;
using Domain.Doctors.Entities;

namespace Domain.Doctors.Contracts;

public interface IDoctorRepository : IRepository<Doctor, Guid>
{
    
}