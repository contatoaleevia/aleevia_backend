using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Identities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ManagerRepository(ApiDbContext context) : Repository<Manager>(context), IManagerRepository
{
    public async Task<Manager?> GetManagerByUserId(Guid userId)
        => await DbSet.FirstOrDefaultAsync(x => x.UserId == userId);
}