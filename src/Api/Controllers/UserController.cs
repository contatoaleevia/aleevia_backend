using System.Web;
using Api.ApiResponses;
using Api.Attributes;
using Application.DTOs.Users.CreateAdminUserDTOs;
using Application.DTOs.Users.IsRegisteredDTOs;
using Application.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/user")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        return Ok(await userService.GetByGuidAsync(id));
    }
    
    [HttpPost("manager")]
    [ApiKey]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreateManagerUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UnauthorizedResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateManagerUser([FromBody] CreateManagerUserRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await userService.CreateManagerUserAsync(request));
    }

    /// <summary>
    /// Verifica se o usuário já está cadastrado no sistema pelo documento.
    /// </summary>
    /// <param name="document">Informar CPF ou CNPJ com ou sem pontuação para verificar</param>
    /// <returns></returns>
    [HttpGet("is-registered/{document}")]
    [ApiKey]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IsRegisteredResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    [Consumes("application/json")]
    public async Task<IActionResult> IsRegistered([FromRoute] string document)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await userService.IsRegisteredAsync(HttpUtility.UrlDecode(document)));
    }

}