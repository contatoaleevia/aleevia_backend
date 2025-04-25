using Api.ApiResponses;
using Api.Attributes;
using Application.DTOs.Users.CreateAdminUserDTOs;
using Application.DTOs.Users.CreateHealthcareUserDTOs;
using Application.DTOs.Users.DeleteUserDTOs;
using Application.DTOs.Users.LoginDTOs;
using Application.DTOs.Users.UpdateUserDTOs;
using Application.Services.Users;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await userService.LoginAsync(loginDto);
        if (result == null)
            return Unauthorized("Email ou senha inválidos.");

        return Ok(result);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateHealthcareProfessionalUser([FromBody] CreateHealthcareUserRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await userService.CreateHealthcareProfessionalUserAsync(request));
    }
    
    [HttpPost("admin")]
    [ApiKey]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreateAdminUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UnauthorizedResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAdminUser([FromBody] CreateAdminUserRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await userService.CreateUserAsAdminAsync(request));
    }

    [HttpPut]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await userService.UpdateUserAsync(requestDto);
        return Ok(response);
    }

    [HttpDelete]
    [AllowAnonymous]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await userService.DeleteUserAsync(requestDto));
    }
}