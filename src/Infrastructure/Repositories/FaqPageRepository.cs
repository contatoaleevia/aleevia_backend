using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Faqs;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FaqPageRepository(ApiDbContext context) : Repository<FaqPage>(context), IFaqPageRepository
{
    public async Task<FaqPage?> GetBySourceIdAsync(Guid sourceId)
    {
        return await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.SourceId == sourceId);
    }

    public async Task<FaqPage?> GetByCustomUrlAsync(string customUrl)
    {
        return await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.CustomUrl == customUrl.ToLower().Trim());
    }
} 