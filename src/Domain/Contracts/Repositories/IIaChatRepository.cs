using CrossCutting.Repositories;
using Domain.Entities.IaChats;

namespace Domain.Contracts.Repositories;

public interface IIaChatRepository : IRepository<IaChat>
{
    Task<List<IaChat>> GetAllAsync();
    Task<IaChat?> GetByIdWithMessagesAsync(Guid id);
    Task CreateMessageAsync(IaMessage message);
} 