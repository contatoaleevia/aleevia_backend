using Application.DTOs.Professionals;
using Application.Services.Professionals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class ProfessionalController(IProfessionalService service) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    public async Task<IActionResult> CreateProfessional([FromBody] CreateProfessionalRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await service.CreateProfessional(requestDto);
        return Ok(response);
    }
}