using Application.DTOs.Users.CreateUserDTOs;
using Application.DTOs.Users.DeleteUserDTOs;
using Application.DTOs.Users.GetUserById;
using Application.DTOs.Users.LoginDTOs;
using Application.DTOs.Users.UpdateUserDTOs;

namespace Application.Services.Users
{
    public interface IUserService
    {
        Task<GetUserByIdResponseDto> GetByGuidAsync(Guid guid);
        Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto);
        Task<CreateUserResponseDto> CreateUserAsync(CreateUserRequestDto requestDto);
        Task<UpdateUserResponseDto> UpdateUserAsync(UpdateUserRequestDto requestDto);
        Task<DeleteUserResponseDto> DeleteUserAsync(DeleteUserRequestDto requestDto);
    }
}