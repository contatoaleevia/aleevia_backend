using Application.DTOs.Users.CreateUserDTOs;
using Application.DTOs.Users.DeleteUserDTOs;
using Application.DTOs.Users.UpdateUserDTOs;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class UserController(IUserService userService) : ApiController
{
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        return Ok(await userService.GetByGuidAsync(id));
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await userService.CreateUserAsync(requestDto);
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