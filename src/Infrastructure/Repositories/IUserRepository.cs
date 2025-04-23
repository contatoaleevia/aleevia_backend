using Domain.Entities.Identities;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByGuidAsync(Guid id);
        Task AddAsync(User dto);
        Task UpdateAsync(User entity, bool saveChanges = true);
        Task DeleteAsync(User entity, bool saveChanges = true);
    }
}
