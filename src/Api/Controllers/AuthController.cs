using Application.DTOs.Users.LoginDTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class AuthController(IAuthService authService) : ApiController
{
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await authService.LoginAsync(loginDto);
        if (result == null)
            return Unauthorized("Email ou senha inválidos");

        return Ok(result);
    }
}