using Application.DTOs.Users.LoginDTOs;
using Application.Helpers;
using CrossCutting.Identities;
using Domain.Entities.Identities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Authentications;

public class AuthService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IGenerateJwtTokenHelper generateJwtTokenHelper,
    IIdentityNotificationHandler identityNotificationHandler
) : IAuthService
{
    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto)
    {
        var result = await signInManager.PasswordSignInAsync(
        requestDto.UserName,
        requestDto.Password,
        requestDto.RememberMe,
        lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            identityNotificationHandler.AddNotifications(new[]
            { new IdentityError { Description = "Credenciais inválidas." }});
            return new LoginResponseDto();
        }

        var user = await userManager.FindByNameAsync(requestDto.UserName);
        if (user is null)
            throw new EmailNotFoundException(requestDto.UserName);
        var roles = await userManager.GetRolesAsync(user);
        var token = generateJwtTokenHelper.GenerateJwtToken(user, roles);

        return new LoginResponseDto
        (
            token,
            user.UserName!,
            user.Email!
        );
    }
}