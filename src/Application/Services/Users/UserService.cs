using Application.DTOs.Users.CreateAdminUserDTOs;
using Application.DTOs.Users.DeleteUserDTOs;
using Application.DTOs.Users.GetUserById;
using Application.DTOs.Users.LoginDTOs;
using Application.DTOs.Users.UpdateUserDTOs;
using Application.Helpers;
using Application.Services.Managers;
using CrossCutting.Databases;
using CrossCutting.Identities;
using Domain.Entities.Identities;
using Domain.Entities.Identities.Enums;
using Domain.Exceptions;
using Domain.Utils;
using Domain.Utils.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Users;

public class UserService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    GenerateJwtTokenHelper generateJwtTokenHelper,
    IIdentityNotificationHandler identityNotificationHandler,
    IManagerService managerService
) : IUserService
{
    public async Task<GetUserByIdResponseDto> GetByGuidAsync(Guid guid)
    {
        var user = await userManager.FindByIdAsync(guid.ToString());
        if (user is null) throw new UserNotFoundException(guid);
        //TODO: Preencher response com os dados do usuário
        return new GetUserByIdResponseDto();
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto)
    {
        var result = await signInManager.PasswordSignInAsync(
            requestDto.Email,
            requestDto.Password,
            requestDto.RememberMe,
            lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            identityNotificationHandler.AddNotifications([
                new IdentityError { Description = "Credenciais inválidas." }
            ]);
            return new LoginResponseDto();
        }

        var user = await userManager.FindByEmailAsync(requestDto.Email);
        if (user is null)
            throw new EmailNotFoundException(requestDto.Email);

        var token = generateJwtTokenHelper.GenerateJwtToken(user);

        return new LoginResponseDto
        (
            token,
            user.UserName!,
            user.Email!
        );
    }

    public async Task<CreateManagerUserResponse> CreateManagerUserAsync(CreateManagerUserRequest request)
    {
        var user = new User(
            email: request.Email,
            phoneNumber: request.PhoneNumber,
            name: request.Name,
            cpf: Document.CreateDocumentAsCpf(request.Cpf),
            cnpj: Document.CreateDocumentAsCnpj(request.Cnpj),
            userType: UserType.CreateAsManager()
        );

        user.AddRoleAdmin();

        using (var scope = ApiTransactionScope.RepeatableRead(true))
        {
            var response = await userManager.CreateAsync(user, request.Password);
            if (!response.Succeeded)
                identityNotificationHandler.AddNotifications(response.Errors);

            await managerService.CreateManager(request.Manager, user.Id);
            scope.Complete();
        }
        
        return new CreateManagerUserResponse();
    }

    // public async Task<UpdateUserResponseDto> UpdateUserAsync(UpdateUserRequestDto requestDto)
    // {
    //     var user = new User(
    //         email: requestDto.Email,
    //         phoneNumber: requestDto.PhoneNumber,
    //         name: requestDto.FirstName,
    //         document: requestDto.Document,
    //         userType: requestDto.UserType);
    //
    //     var response = await userManager.UpdateAsync(user);
    //     if (response.Succeeded)
    //         return new UpdateUserResponseDto(user.Id, user.UserName!, user.Email!);
    //
    //     identityNotificationHandler.AddNotifications(response.Errors);
    //     return new UpdateUserResponseDto();
    // }
    //
    // public async Task<DeleteUserResponseDto> DeleteUserAsync(DeleteUserRequestDto requestDto)
    // {
    //     var user = await userManager.FindByIdAsync(requestDto.Guid.ToString());
    //     if (user is null) throw new UserNotFoundException(requestDto.Guid);
    //
    //     var response = await userManager.DeleteAsync(user);
    //     if (response.Succeeded)
    //         return new DeleteUserResponseDto(requestDto.Guid);
    //
    //     identityNotificationHandler.AddNotifications(response.Errors);
    //     return new DeleteUserResponseDto(requestDto.Guid);
    // }
}