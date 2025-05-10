using Api.ApiResponses;
using Application.DTOs.Users.LoginDTOs;
using Application.Services.Authentications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    /// <summary>
    /// Efetua o Login do usuário.
    /// </summary>
    /// <param name="loginDto">Objeto de requisição para login:
    /// <summary/>UserName: Documento do usuário (CPF ou CNPJ), pode ser informado com ou sem pontuação
    /// <summary/>Password: Senha do usuário
    /// <summary/>RememberMe (opcional): Indica se o usuário deseja permanecer logado
    /// </param>
    /// <returns>Dados de autenticação do usuário incluindo token JWT</returns>
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await authService.LoginAsync(loginDto));
    }
}