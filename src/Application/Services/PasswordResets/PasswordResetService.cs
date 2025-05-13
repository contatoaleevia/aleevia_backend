using Application.DTOs.Email;
using Application.DTOs.Users.PasswordResetDTOs;
using CrossCutting.Extensions;
using CrossCutting.Identities;
using Domain.Entities.Identities;
using Domain.Exceptions.Passwords;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace Application.Services.PasswordResets;

public class PasswordResetService(
    UserManager<User> userManager,
    IIdentityNotificationHandler identityNotificationHandler,
    IEmailService emailService,
    IConfiguration configuration
) : IPasswordResetService
{
    private readonly string _frontendUrl = configuration.GetValue<string>("FrontendUrl") ?? throw new InvalidOperationException("FrontendUrl não configurada no appsettings");

    public async Task<RequestPasswordResetResponseDTO> RequestPasswordResetAsync(RequestPasswordResetDTO request)
    {
        var user = await FindUserByDocumentAsync(request.Document);
        if (user == null)
        {
            return new RequestPasswordResetResponseDTO{Message = "Não foi possível encontrar um usuário com o documento informado." };
        }

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var resetLink = $"{_frontendUrl}/reset-password?token={Uri.EscapeDataString(token)}";

        await emailService.SendEmailAsync(
            to: user.Email!,
            subject: PasswordResetEmailTemplate.GetSubject(),
            body: PasswordResetEmailTemplate.GetBody(user.Name, resetLink),
            isHtml: true
        );

        return new RequestPasswordResetResponseDTO
        {
            Email = user.Email!,
            Message = "Um e-mail com instruções para redefinição de senha foi enviado para o endereço cadastrado."
        };
    }

    public async Task ResetPasswordAsync(ResetPasswordDTO request)
    {
        var user = await FindUserByDocumentAsync(request.Document) ?? throw new InvalidPasswordResetTokenException();
        var result = await userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

        if (!result.Succeeded)
        {
            identityNotificationHandler.AddNotifications(result.Errors);
            throw new PasswordResetFailedException();
        }
    }

    private async Task<User?> FindUserByDocumentAsync(string document)
    {
        ArgumentNullException.ThrowIfNull(document);
        document = document.RemoveSpecialCharacters();

        return await userManager.Users
            .FirstOrDefaultAsync(x => x.Cpf.Value == document || x.Cnpj.Value == document);
    }
} 