using Api.Attributes;
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
        var response = await userService.CreateHealthcareProfessionalUserAsync(request);
        return Ok(response);
    }
    
    [HttpPost("admin")]
    [ApiKey]
    public async Task<IActionResult> CreateAdminUser([FromBody] CreateHealthcareUserRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await userService.CreateHealthcareProfessionalUserAsync(request);
        return Ok(response);
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
        var response = await userService.DeleteUserAsync(requestDto);
        return Ok();
    }
}