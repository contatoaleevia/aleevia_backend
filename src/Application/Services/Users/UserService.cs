using Application.DTOs.Users.CreateAdminUserDTOs;
using Application.DTOs.Users.CreateHealthcareUserDTOs;
using Application.DTOs.Users.DeleteUserDTOs;
using Application.DTOs.Users.GetUserById;
using Application.DTOs.Users.LoginDTOs;
using Application.DTOs.Users.UpdateUserDTOs;
using Application.Helpers;
using CrossCutting.Identities;
using Domain.Entities.Identities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Users;

public class UserService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    GenerateJwtTokenHelper generateJwtTokenHelper,
    IIdentityNotificationHandler identityNotificationHandler
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
            identityNotificationHandler.AddNotifications([new IdentityError { Description = "Credenciais inválidas." }]);
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

    public async Task<CreateHealthcareUserResponse> CreateHealthcareProfessionalUserAsync(CreateHealthcareUserRequest request)
    {
        var user = new User(
            email: request.Email,
            phoneNumber: request.PhoneNumber,
            firstName: request.FirstName,
            lastName: request.LastName,
            preferredName: request.PreferredName,
            gender: request.Gender,
            document: request.Document,
            userType: request.UserType);

        var response = await userManager.CreateAsync(user, request.Password);
        if (response.Succeeded)
            return new CreateHealthcareUserResponse(user.Id, user.UserName!, user.Email!);

        identityNotificationHandler.AddNotifications(response.Errors);
        return new CreateHealthcareUserResponse();
    }
    
    public async Task<CreateAdminUserResponse> CreateUserAsAdminAsync(CreateAdminUserRequest request)
    {
        var user = new User(
            email: request.Email,
            phoneNumber: request.PhoneNumber,
            firstName: request.FirstName,
            lastName: request.LastName,
            preferredName: request.PreferredName,
            gender: request.Gender,
            document: request.Document,
            userType: request.UserType);
        
        user.AddRoleAdmin();

        var response = await userManager.CreateAsync(user, request.Password);
        if (response.Succeeded)
            return new CreateAdminUserResponse(user.Id, user.UserName!, user.Email!);

        identityNotificationHandler.AddNotifications(response.Errors);
        return new CreateAdminUserResponse();
    }

    public async Task<UpdateUserResponseDto> UpdateUserAsync(UpdateUserRequestDto requestDto)
    {
        var user = new User(
            email: requestDto.Email,
            phoneNumber: requestDto.PhoneNumber,
            firstName: requestDto.FirstName,
            lastName: requestDto.LastName,
            preferredName: requestDto.PreferredName,
            gender: requestDto.Gender,
            document: requestDto.Document,
            userType: requestDto.UserType);

        var response = await userManager.UpdateAsync(user);
        if (response.Succeeded)
            return new UpdateUserResponseDto(user.Id, user.UserName!, user.Email!);

        identityNotificationHandler.AddNotifications(response.Errors);
        return new UpdateUserResponseDto();
    }

    public async Task<DeleteUserResponseDto> DeleteUserAsync(DeleteUserRequestDto requestDto)
    {
        var user = await userManager.FindByIdAsync(requestDto.Guid.ToString());
        if (user is null) throw new UserNotFoundException(requestDto.Guid);

        var response = await userManager.DeleteAsync(user);
        if (response.Succeeded)
            return new DeleteUserResponseDto(requestDto.Guid);

        identityNotificationHandler.AddNotifications(response.Errors);
        return new DeleteUserResponseDto(requestDto.Guid);
    }

    
}