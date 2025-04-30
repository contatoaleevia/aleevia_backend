using Application.DTOs.Users.LoginDTOs;
using Application.Services;
using Application.Services.Authentications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await authService.LoginAsync(loginDto));
    }
}