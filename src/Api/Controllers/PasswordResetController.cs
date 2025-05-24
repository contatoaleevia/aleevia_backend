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
    public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await passwordResetService.RequestPasswordResetAsync(request);
        return Ok(response);
    }

    [HttpPost("reset")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await passwordResetService.ResetPasswordAsync(request);
        return Ok(new { message = "Senha redefinida com sucesso." });
    }
} 