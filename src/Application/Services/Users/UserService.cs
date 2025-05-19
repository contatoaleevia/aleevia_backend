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
using Application.Services.Professionals;
using Application.DTOs.Professionals;
using Domain.Entities.Professionals;
using Domain.Exceptions.Professionals;
using Domain.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
namespace Application.Services.Users;

public class UserService(
    UserManager<User> userManager,
    IIdentityNotificationHandler identityNotificationHandler,
    IManagerService managerService,
    IEmailService emailService,
    IPatientService patientService,
    IProfessionalRepository professionalRepository,
    IConfiguration configuration
) : IUserService
{

    private readonly string _frontendUrl = configuration.GetValue<string>("FrontendUrl") ?? throw new InvalidOperationException("FrontendUrl não configurada no appsettings");
    
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
            var verificationLink = $"{_frontendUrl}/verify-email/{user.Id}";

            try
            {
                await emailService.SendEmailAsync(
                    to: user.Email!,
                    subject: WelcomeEmailTemplate.GetSubject(),
                    body: WelcomeEmailTemplate.GetBody(verificationLink),
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

    public async Task<Tuple<Professional, string?>> CreateProfessionalUserAsync(CreateProfessionalUserRequest request)
    {
        var user = await userManager
            .Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .Include(x => x.Manager)
            .Where(x => x.Cpf.Value == request.Cpf.RemoveSpecialCharacters())
            .FirstOrDefaultAsync();

        if (user is not null)
        {
            user.SetUserType(UserType.CreateAsHealthcareProfessional());
            if (!user.UserRoles.Any(x => x.Role.Name == Role.Professional.Name))
                user.SetRole(Role.Professional);
            if (!user.UserRoles.Any(x => x.Role.Name == Role.Admin.Name))
                user.SetRole(Role.Admin);

            var manager = await managerService.GetManagerByUserIdAsync(user.Id) ??
                          await managerService.CreateManagerWhenNotExists(user.Id, ManagerType.CreateAsIndividual(), null);

            var existingProfessional = await professionalRepository.GetByManagerIdAsync(manager.Id);
            if (existingProfessional is not null)
                throw new ProfessionalAlreadyExistsException(request.Cpf);
                          
            var newProfessional = new Professional(manager.Id, request.Cpf, true, request.Name, request.Email);
            return new Tuple<Professional, string?>(newProfessional, null);
        }
        else
        {
            user = new User(
                email: request.Email,
                name: request.Name,
                cpf: request.Cpf,
                cnpj: null,
                phoneNumber: null,
                userType: UserType.CreateAsHealthcareProfessional());

            var tempPassword = RandomGenerator.Generate(lenght: 10);
            await CreateUserAsync(user, tempPassword);

            var manager =
                await managerService.CreateManagerWhenNotExists(user.Id, ManagerType.CreateAsIndividual(), null);
            var newProfessional = new Professional(manager.Id, request.Cpf, false, request.Name, request.Email);
            return new Tuple<Professional, string?>(newProfessional, tempPassword);
        }
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
        var user = await userManager.Users.FirstOrDefaultAsync(x =>
            x.Cpf.Value == document || x.Cnpj.Value == document);
        return new IsRegisteredResponse(IsRegistered: user is not null, UserId: user?.Id);
    }
}