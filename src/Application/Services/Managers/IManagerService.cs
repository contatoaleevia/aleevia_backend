using Application.DTOs.Users.CreateAdminUserDTOs;
using Domain.Entities.Identities;

namespace Application.Services.Managers;

public interface IManagerService
{
    Task CreateManager(CreateManagerRequest request, Guid userId);
    Task<Manager> CreateManagerWhenNotExists(Guid userId, ManagerType managerType, string? corporateName);
}