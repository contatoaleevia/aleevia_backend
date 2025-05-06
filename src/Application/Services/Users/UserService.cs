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
using Application.Services.Patients;
using Application.DTOs.Patients.CreatePatientDTOs;

namespace Application.Services.Users;

public class UserService(
    UserManager<User> userManager,
    IIdentityNotificationHandler identityNotificationHandler,
    IManagerService managerService,
    IEmailService emailService,
    IPatientService patientService
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
            await CreateUserAsync(user, request.Password);
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

    public async Task<CreatePatientUserResponse> CreatePatientUserAsync(CreatePatientUserRequest request)
    {
        var user = new User(
            email: request.Email,
            phoneNumber: request.PhoneNumber,
            name: request.Name,
            cpf: request.Cpf,
            cnpj: null,
            userType: UserType.CreateAsPatient()
        );
        
        using (var scope = ApiTransactionScope.RepeatableRead(true))
        {
            await CreateUserAsync(user, request.Password);
            await patientService.CreatePatient(request, user.Id);

            scope.Complete();
        }
        
        return new CreatePatientUserResponse(user.Id);
    }

    private async Task CreateUserAsync(User user, string password)
    {
        var response = await userManager.CreateAsync(user, password);
        if (!response.Succeeded)
            identityNotificationHandler.AddNotifications(response.Errors);
    }

    public async Task<IsRegisteredResponse> IsRegisteredAsync(string document)
    {
        document = document.RemoveSpecialCharacters();
        var user = await userManager.Users.FirstOrDefaultAsync(x => x.Cpf.Value == document || x.Cnpj.Value == document);
        return new IsRegisteredResponse(IsRegistered: user is not null, UserId: user?.Id);
    }
}