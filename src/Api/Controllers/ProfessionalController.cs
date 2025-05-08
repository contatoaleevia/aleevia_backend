using Api.ApiResponses;
using Application.DTOs.Professionals;
using Application.Services.Professionals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/professional")]
public class ProfessionalController(IProfessionalService service) : ControllerBase
{
    /// <summary>
    /// Cria um Profissional de Saúde.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateProfessional([FromBody] CreateProfessionalRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await service.CreateProfessional(requestDto);
        return Ok(response);
    }
}