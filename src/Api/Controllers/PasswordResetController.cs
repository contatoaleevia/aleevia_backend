using Application.DTOs.Users.PasswordResetDTOs;
using Application.Services.PasswordResets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/password")]
public class PasswordResetController(IPasswordResetService passwordResetService) : ControllerBase
{
    [HttpPost("request")]
    [AllowAnonymous]
    public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetDTO request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await passwordResetService.RequestPasswordResetAsync(request);
        return Ok("Se existe um usuário com o documento informado, você receberá um e-mail com instruções para redefinir sua senha.");
    }

    [HttpPost("reset")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await passwordResetService.ResetPasswordAsync(request);
        return Ok("Senha redefinida com sucesso.");
    }
} 