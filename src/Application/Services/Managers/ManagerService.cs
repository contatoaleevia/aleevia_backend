using Application.DTOs.Users.CreateAdminUserDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Identities;
using Domain.Exceptions;

namespace Application.Services.Managers;

public class ManagerService(IManagerRepository repository) : IManagerService
{
    public async Task CreateManager(CreateManagerRequest request, Guid userId)
    {
        try
        {
            var manager = new Manager(
                userId: userId,
                managerType: new ManagerType(request.TypeId),
                corporateName: request.CorporateName
            );
        
            await repository.CreateAsync(manager);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new CreateManagerException(userId);
        }
    }

    public async Task<Manager> CreateManagerWhenNotExists(Guid userId, ManagerType managerType, string? corporateName)
    {
        var manager = await repository.GetManagerByUserId(userId);
        if (manager is not null)
            return manager;

        manager = new Manager(
            userId,
            managerType,
            corporateName);
        await repository.CreateAsync(manager);
        return manager;
    }

    public async Task<Manager?> GetManagerByUserIdAsync(Guid userId)
    {
        return await repository.GetManagerByUserId(userId);
    }
}