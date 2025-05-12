using CrossCutting.Repositories;
using Domain.Entities.Faqs;

namespace Domain.Contracts.Repositories;

public interface IFaqPageRepository : IRepository<FaqPage>
{
    Task<FaqPage?> GetBySourceIdAsync(Guid sourceId);
    Task<FaqPage?> GetByCustomUrlAsync(string customUrl);
}