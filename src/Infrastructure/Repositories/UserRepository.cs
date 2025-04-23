using Domain.Entities.Identities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityApiDbContext _context;

        public UserRepository(IdentityApiDbContext context) => _context = context;

        public async Task<User?> GetByGuidAsync(Guid guid)
        {
            return await _context.Users.FindAsync(guid);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity, bool saveChanges = true)
        {
            _context.Update(entity);

            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity, bool saveChanges = true)
        {
            _context.Remove(entity);

            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
