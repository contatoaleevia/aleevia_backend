using System.Threading.Tasks;
using Api.ApiResponses;
using Application.DTOs.HealthcareProfessionals;
using Application.Services.HealthcareProfessionals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/professions")]
public class ProfessionsController(IProfessionService professionService) 
    : ControllerBase
{
    /// <summary>
    /// Obtém todas as profissões de saúde cadastradas no sistema.
    /// </summary>
    /// <returns>Lista de todas as profissões ativas</returns>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(GetProfessionsResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await professionService.GetAllActiveAsync());
    }
} 
