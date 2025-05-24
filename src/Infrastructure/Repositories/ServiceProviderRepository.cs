using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.ServiceProviders;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ServiceProviderRepository(ApiDbContext context) : Repository<ServiceProvider>(context), IServiceProviderRepository
{
    public async Task<List<ServiceProvider>> GetAllAsync(Guid officeId)
    {
        return await DbSet
            .Where(sp => sp.OfficeId == officeId)
            .ToListAsync();
    }

    public async Task<List<ServiceProvider>> SearchAsync(Guid officeId, string? cnpj = null, string? name = null)
    {
        var query = DbSet.AsQueryable();

        if (!string.IsNullOrWhiteSpace(cnpj))
            query = query.Where(sp => sp.Cnpj.Value == cnpj);

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(sp => sp.Name.Contains(name));

        query = query.Where(sp => sp.OfficeId == officeId);

        return await query.ToListAsync();
    }
} 