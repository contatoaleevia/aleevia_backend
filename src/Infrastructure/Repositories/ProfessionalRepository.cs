using CrossCutting.Extensions;
using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Professionals;
using Domain.Entities.ValueObjects;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ProfessionalRepository(ApiDbContext context) : Repository<Professional>(context), IProfessionalRepository
{
    public async Task<Professional?> GetByCpfAsync(string cpf)
    {
        return await DbSet
            .Include(x => x.Manager)
            .FirstOrDefaultAsync(x => x.Manager.Cpf.Value == cpf.RemoveSpecialCharacters());
    }
}