using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.Faqs;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class FaqRepository(ApiDbContext context) : Repository<Faq>(context), IFaqRepository
{
    public async Task<List<Faq>> GetAllAsync(Guid guid)
    {
        return await context.Set<Faq>()
            .Where(x => x.SourceId == guid && x.IsActive)
            .ToListAsync();
    }

    public async Task<int> CountBySourceIdAsync(Guid sourceId)
    {
        return await DbSet
            .AsNoTracking()
            .CountAsync(f => f.SourceId == sourceId && f.IsActive);
    }

    public async Task<List<FaqCategoryCount>> GetCategoriesBySourceIdAsync(Guid sourceId)
    {
        var faqs = await DbSet
            .AsNoTracking()
            .Where(f => f.SourceId == sourceId && f.IsActive)
            .ToListAsync();

        return [.. faqs
            .GroupBy(f => f.FaqCategory.CategoryType)
            .Select(g => new FaqCategoryCount
            {
                Category = g.First().FaqCategory.CategoryTypeName,
                Count = g.Count()
            })
            .OrderByDescending(x => x.Count)
            .Take(5)];
    }
}