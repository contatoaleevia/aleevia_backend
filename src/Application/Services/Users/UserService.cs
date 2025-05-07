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
using Application.DTOs.Users.RetrieveUserDTOs;
using Application.Helpers;

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

    public async Task<Manager> CreateProfessionalUserAsync(CreateProfessionalUserRequest request)
    {
        var user = await userManager
            .Users
            .Where(x => x.Cpf.Value == request.Cpf.RemoveSpecialCharacters())
            .FirstOrDefaultAsync();

        if (user is not null)
        {
            //TODO: Adicionar Role de HealthCareProfessional e Manager caso não tenha
            return user;
        }
            
        user = new User(
            email: request.Email,
            name: request.Name,
            cpf: request.Cpf,
            cnpj: null,
            phoneNumber: null,
            userType: UserType.CreateAsHealthcareProfessional());

        var tempPassword = RandomGenerator.Generate(lenght: 10);
        await CreateUserAsync(user, tempPassword);
        
        //TODO: Verificar se tem manager
        //TODO: Caso não, criar um manager com o mesmo cpf
        //TODO: Caso tenha, retornar o manager para vincular no profissional
        return manager;        
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