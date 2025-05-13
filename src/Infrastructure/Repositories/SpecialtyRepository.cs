using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.HealthcareProfessionals;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class SpecialtyRepository(ApiDbContext context) : Repository<Specialty>(context), ISpecialtyRepository
{
} 