using Application.DTOs.Users.LoginDTOs;
using Application.Helpers;
using CrossCutting.Identities;
using Domain.Entities.Identities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            identityNotificationHandler.AddNotifications([
                new IdentityError { Description = "Credenciais inválidas." }
            ]);

        var user = await userManager.Users
            .AsNoTracking()
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Cpf.Value == requestDto.Document || x.Cnpj.Value == requestDto.Document);

        if (user is null)
            throw new EmailNotFoundException(requestDto.UserName);
        var token = generateJwtTokenHelper.GenerateJwtToken(user);

        return new LoginResponseDto
        (
            token,
            user.UserName!,
            user.Email!
        );
    }
}