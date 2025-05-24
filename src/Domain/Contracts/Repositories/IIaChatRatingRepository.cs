using CrossCutting.Repositories;
using Domain.Entities.IaChats;

namespace Domain.Contracts.Repositories;

public interface IIaChatRatingRepository : IRepository<IaChatRating>
{
    Task<IEnumerable<IaChatRating>> GetBySourceIdAsync(Guid sourceId);
} 