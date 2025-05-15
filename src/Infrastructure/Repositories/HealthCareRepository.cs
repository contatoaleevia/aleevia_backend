using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.HealthCares;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;
public class HealthCareRepository(ApiDbContext context) : Repository<HealthCare>(context), IHealthCareRepository
{
}