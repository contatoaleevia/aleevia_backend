using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.ServiceTypes;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class ServiceTypeRepository(ApiDbContext context) : Repository<ServiceType>(context), IServiceTypeRepository 
{
    public async Task<List<ServiceType>> GetAllAsync()
    {
        return await context
        .ServiceTypes
        .AsNoTracking()
        .ToListAsync();
    }
}