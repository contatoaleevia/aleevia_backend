using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.HealthcareProfessionals;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class ProfessionalProfessionRepository(ApiDbContext context) : Repository<Profession>(context), IProfessionalProfessionRepository
{
    public async Task<List<Profession>> GetAllAsync()
    {
        return await context.Set<Profession>()
            .Include(p => p.Specialties.Where(s => s.Active))
            .ThenInclude(s => s.SubSpecialties.Where(ss => ss.Active))
            .Where(p => p.Active)
            .OrderBy(p => p.Name)
            .ToListAsync();
    }
}