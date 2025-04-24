using Application.DTOs.Users.CreateUserDTOs;
using Application.DTOs.Users.GetUserById;

namespace Application.Services
{
    public interface IUserService
    {
        Task<GetUserByIdResponse> GetByGuidAsync(Guid guid);
        Task<CreateUserResponseDto> CreateUserAsync(CreateUserRequestDto requestDto);
        // Task UpdateAsync(CreateUserRequestDto requestDto);
        // Task DeleteAsync(CreateUserRequestDto requestDto);
    }
}