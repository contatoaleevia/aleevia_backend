using Application.DTOs.Users.CreateAdminUserDTOs;
using Application.DTOs.Users.GetUserById;
using Application.DTOs.Users.IsRegisteredDTOs;

namespace Application.Services.Users
{
    public interface IUserService
    {
        Task<GetUserByIdResponseDto> GetByGuidAsync(Guid guid);
        Task<CreateManagerUserResponse> CreateManagerUserAsync(CreateManagerUserRequest request);
        Task<IsRegisteredResponse> IsRegisteredAsync(string document);
    }
}