using Application.DTOs.Users.LoginDTOs;
using Application.Helpers;
using CrossCutting.Identities;
using Domain.Contracts.Repositories;
using Domain.Entities.Identities;
using Domain.Exceptions.Authentications;
using Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Authentications;

public class AuthService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IGenerateJwtTokenHelper generateJwtTokenHelper,
    IIdentityNotificationHandler identityNotificationHandler,
    IManagerRepository managerRepository
) : IAuthService
{
    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto)
    {
        var user = await userManager.Users
            .AsNoTracking()
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Cpf.Value == requestDto.Document || x.Cnpj.Value == requestDto.Document);

        if (user is null)
            throw new InvalidCredentialsException();
        
        var result = await signInManager.PasswordSignInAsync(
            user,
            requestDto.Password,
            requestDto.RememberMe,
            lockoutOnFailure: true);

        if (!result.Succeeded)
            identityNotificationHandler.AddNotifications([
                new IdentityError { Description = "Credenciais inválidas." }
            ]);
        
        var managerId = await managerRepository.GetDbContext<ApiDbContext>()
            .Managers
            .Include(x => x.User)
            .AsNoTracking()
            .Where(x => x.UserId == user.Id)
            .Select(x => x.Id).FirstOrDefaultAsync();
        
        var token = generateJwtTokenHelper.GenerateJwtToken(user, managerId, requestDto.RememberMe);

        return LoginResponseDto.FromUser(user, token, managerId);
    }
}