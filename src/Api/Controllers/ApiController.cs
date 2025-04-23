using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController : ControllerBase
{
    private readonly IUserService _userService;

    public ApiController(IUserService userService) => _userService = userService;

    [HttpGet("get")]
    public async Task<IActionResult> GetUser([FromQuery] Guid guid)
    {
        var user = await _userService.GetByGuidAsync(guid);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody] UserDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _userService.AddAsync(dto);
        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto dto)
    {
        if (!ModelState.IsValid)return BadRequest(ModelState);

        await _userService.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser([FromBody] UserDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _userService.DeleteAsync(dto);
        return Ok();
    }
}
