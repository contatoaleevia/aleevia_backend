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
            .Where(x => x.SourceId == guid)
            .ToListAsync();
    }
}