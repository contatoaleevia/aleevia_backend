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
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IaChat?> GetByIdWithMessagesAsync(Guid id)
    {
        return await context.IaChats
            .Include(c => c.Messages)
            .ThenInclude(m => m.SenderType)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task CreateMessageAsync(IaMessage message)
    {
        await context.IaMessages.AddAsync(message);
        await context.SaveChangesAsync();
    }
} 