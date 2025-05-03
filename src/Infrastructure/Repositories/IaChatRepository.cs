using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.IaChats;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class IaChatRepository(ApiDbContext context) : Repository<IaChat>(context), IIaChatRepository
{
    public async Task<List<IaChat>> GetAllAsync()
    {
        return await DbSet
            .Include(x => x.Source)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IaChat?> GetByIdWithMessagesAsync(Guid id)
    {
        return await DbSet
            .Include(x => x.Source)
            .Include(x => x.Messages)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
} 