using Application.DTOs.Users.CreateAdminUserDTOs;

namespace Application.Services.Managers;

public interface IManagerService
{
    Task CreateManager(CreateManagerRequest request, Guid userId);
}