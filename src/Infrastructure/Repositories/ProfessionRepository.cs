using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.HealthcareProfessionals;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class ProfessionRepository(ApiDbContext context) : Repository<Profession>(context), IProfessionRepository 
{
    private readonly DbSet<Speciality> _specialtiesDb = context.Set<Speciality>();
    private readonly DbSet<SubSpecialty> _subspecialtiesDb = context.Set<SubSpecialty>();

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

    public async Task<Speciality?> GetSpecialityByIdAsync(Guid id)
        => await _specialtiesDb.FindAsync(id);

    public async Task<SubSpecialty?> GetSubSpecialityByIdAsync(Guid? id)
        => id.HasValue ? await _subspecialtiesDb.FindAsync(id.Value) : null;
}