using Application.DTOs;
using Domain.Entities.Identities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<User?> GetByGuidAsync(Guid guid)
        {
            return await _userRepository.GetByGuidAsync(guid);
        }

        public async Task AddAsync(UserDto dto)
        {
            var user = new User(userName: dto.Email, dto.Email, dto.PhoneNumber, dto.Gender, dto.FirstName, dto.LastName, dto.PreferredName, dto.Active, dto.Document);
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var user = new User(userName: dto.Email, dto.Email, dto.PhoneNumber, dto.Gender, dto.FirstName, dto.LastName, dto.PreferredName, dto.Active, dto.Document);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(UserDto dto)
        {
            var user = new User(userName: dto.Email, dto.Email, dto.PhoneNumber, dto.Gender, dto.FirstName, dto.LastName, dto.PreferredName, dto.Active, dto.Document);
            await _userRepository.DeleteAsync(user);
        }
    }
}
