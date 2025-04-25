using Application.DTOs.Users.CreateUserDTOs;
using Application.DTOs.Users.DeleteUserDTOs;
using Application.DTOs.Users.GetUserById;
using Application.DTOs.Users.UpdateUserDTOs;

namespace Application.Services
{
    public interface IUserService
    {
        Task<GetUserByIdResponse> GetByGuidAsync(Guid guid);
        Task<CreateUserResponseDto> CreateUserAsync(CreateUserRequestDto requestDto);
        Task<UpdateUserResponseDto> UpdateUserAsync(UpdateUserRequestDto requestDto);
        Task<DeleteUserResponseDto> DeleteUserAsync(DeleteUserRequestDto requestDto);
    }
}