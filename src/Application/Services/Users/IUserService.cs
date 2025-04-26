using Application.DTOs.Users.CreateAdminUserDTOs;
using Application.DTOs.Users.CreateHealthcareUserDTOs;
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
        // Task<CreateHealthcareUserResponse> CreateHealthcareProfessionalUserAsync(CreateHealthcareUserRequest request);
        Task<CreateManagerUserResponse> CreateManagerUserAsync(CreateManagerUserRequest request);
        // Task<UpdateUserResponseDto> UpdateUserAsync(UpdateUserRequestDto requestDto);
        // Task<DeleteUserResponseDto> DeleteUserAsync(DeleteUserRequestDto requestDto);
    }
}