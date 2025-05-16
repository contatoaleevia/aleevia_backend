using CrossCutting.Repositories;
using Domain.Entities.Faqs;

namespace Domain.Contracts.Repositories;
public interface IFaqRepository : IRepository<Faq>
{
    Task<List<Faq>> GetAllAsync(Guid guid);
    Task<int> CountBySourceIdAsync(Guid sourceId);
}