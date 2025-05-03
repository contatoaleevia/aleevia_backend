using Application.DTOs.Users.CreateAdminUserDTOs;
using Application.Services.Managers;
using CrossCutting.Databases;
using CrossCutting.Identities;
using Domain.Entities.Identities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Application.DTOs.Email;
using Application.DTOs.Users.IsRegisteredDTOs;
using CrossCutting.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Users;

public class UserService(
    UserManager<User> userManager,
    IIdentityNotificationHandler identityNotificationHandler,
    IManagerService managerService,
    IEmailService emailService
) : IUserService
{
    public async Task<CreateManagerUserResponse> CreateManagerUserAsync(CreateManagerUserRequest request)
    {
        var user = new User(
            email: request.Email,
            phoneNumber: request.PhoneNumber,
            name: request.Name,
            cpf: request.Cpf,
            cnpj: request.Cnpj,
            userType: UserType.CreateAsManager()
        );

        using (var scope = ApiTransactionScope.RepeatableRead(true))
        {
            var response = await userManager.CreateAsync(user, request.Password);
            if (!response.Succeeded)
                identityNotificationHandler.AddNotifications(response.Errors);

            await managerService.CreateManager(request.Manager, user.Id);

            try
            {
                await emailService.SendEmailAsync(
                    to: user.Email!,
                    subject: WelcomeEmailTemplate.GetSubject(),
                    body: WelcomeEmailTemplate.GetBody(user.Name),
                    isHtml: true
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha ao enviar email de boas-vindas: {ex.Message}");
            }

            scope.Complete();
        }
        
        return new CreateManagerUserResponse(user.Id);
    }

    public async Task<IsRegisteredResponse> IsRegisteredAsync(string document)
    {
        document = document.RemoveSpecialCharacters();
        var user = await userManager.Users.FirstOrDefaultAsync(x => x.Cpf.Value == document || x.Cnpj.Value == document);
        return new IsRegisteredResponse(IsRegistered: user is not null, UserId: user?.Id);
    }
}