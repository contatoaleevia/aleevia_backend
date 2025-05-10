using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.HealthcareProfessionals;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class ProfessionRepository(ApiDbContext context) : Repository<Profession>(context), IProfessionRepository 
{
    private readonly DbSet<Specialty> specialtiesDB = context.Set<Specialty>();
    private readonly DbSet<SubSpecialty> subspecialtiesDB = context.Set<SubSpecialty>();

    public async Task<List<Profession>> GetAllActiveAsync()
    {
        return await DbSet
            .Where(p => p.Active)
            .OrderBy(p => p.Name)
            .Include(p => p.Specialties
                .Where(s => s.Active)
                .OrderBy(s => s.Name))
            .ThenInclude(s => s.SubSpecialties
                .Where(ss => ss.Active)
                .OrderBy(ss => ss.Name))
            .AsSplitQuery()
            .ToListAsync();
    }

    public async Task<Specialty?> GetSpecialityByIdAsync(Guid id)
        => await specialtiesDB.FindAsync(id);

    public async Task<SubSpecialty?> GetSubSpecialityByIdAsync(Guid? id)
        => id.HasValue ? await subspecialtiesDB.FindAsync(id.Value) : null;
}