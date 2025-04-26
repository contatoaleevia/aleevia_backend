using System.Threading.Tasks;
using Api.ApiResponses;
using Application.DTOs.HealthcareProfessionals;
using Application.Services.HealthcareProfessionals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/professional-professions")]
public class ProfessionalProfessionsController(IProfessionalProfessionService professionalProfessionService) 
    : ControllerBase
{
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GetProfessionalProfessionsResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await professionalProfessionService.GetAllAsync());
    }
} 