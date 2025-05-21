using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.IaChats;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class IaChatRatingRepository(ApiDbContext context) : Repository<IaChatRating>(context), IIaChatRatingRepository
{
    public async Task<IEnumerable<IaChatRating>> GetAllAsync()
    {
        return await DbSet
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<IaChatRating>> GetBySourceIdAsync(Guid sourceId)
    {
        return await DbSet
            .AsNoTracking()
            .Where(r => r.Chat.HashSourceId == sourceId)
            .ToListAsync();
    }
} 