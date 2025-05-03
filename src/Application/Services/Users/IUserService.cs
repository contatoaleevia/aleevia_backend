using Application.DTOs.Users.CreateAdminUserDTOs;
using Application.DTOs.Users.IsRegisteredDTOs;

namespace Application.Services.Users
{
    public interface IUserService
    {
        Task<CreateManagerUserResponse> CreateManagerUserAsync(CreateManagerUserRequest request);
        Task<IsRegisteredResponse> IsRegisteredAsync(string document);
    }
}