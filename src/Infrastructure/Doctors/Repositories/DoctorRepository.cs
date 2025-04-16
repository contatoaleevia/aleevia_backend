using CrossCutting.Repositories;
using Domain.Doctors.Contracts;
using Domain.Doctors.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Doctors.Repositories;

public class DoctorRepository(ApiDbContext dbContext) : Repository<Doctor, Guid>(dbContext), IDoctorRepository;