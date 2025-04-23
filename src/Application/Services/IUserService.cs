using Application.DTOs;
using Domain.Entities.Identities;

namespace Application.Services
{
    public interface IUserService
    {
        Task<User?> GetByGuidAsync(Guid guid);
        Task AddAsync(UserDto dto);
        Task UpdateAsync(UserDto dto);
        Task DeleteAsync(UserDto dto);
    }
}