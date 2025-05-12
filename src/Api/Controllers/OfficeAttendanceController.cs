using Api.ApiResponses;
using Application.DTOs.OfficeAttendance.CreateOfficeAttendanceDTOs;
using Application.DTOs.OfficeAttendance.DeactivateOfficeAttendanceDTOs;
using Application.Services.OfficeAttendances;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/office-attendance")]
public class OfficeAttendanceController(IOfficeAttendanceService officeAttendanceService) : ControllerBase
{
    /// <summary>
    /// Obtém todos os atendimentos relacionados a um consultório específico.
    /// </summary>
    /// <param name="officeId">ID do consultório para buscar os atendimentos</param>
    /// <returns>Lista de atendimentos do consultório</returns>
    [HttpGet("office/{officeId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllByOfficeId(Guid officeId)
    {
        return Ok(await officeAttendanceService.GetAllByOfficeIdAsync(officeId));
    }

    /// <summary>
    /// Cria um novo registro de atendimento para um consultório.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados do atendimento:
    /// <summary/>OfficeId: ID do consultório
    /// <summary/>DayOfWeek: Dia da semana (0-6, onde 0 é domingo)
    /// <summary/>StartTime: Hora de início do atendimento
    /// <summary/>EndTime: Hora de término do atendimento
    /// </param>
    /// <returns>Informações do atendimento criado</returns>
    [HttpPost]
    [AllowAnonymous]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreateOfficeAttendanceResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateOfficeAttendanceRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await officeAttendanceService.CreateAsync(requestDto));
    }

    /// <summary>
    /// Desativa um registro de atendimento de consultório.
    /// </summary>
    /// <param name="id">ID do atendimento a ser desativado</param>
    /// <returns>Confirmação da desativação</returns>
    [HttpDelete("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Deactivate([FromRoute] Guid id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(await officeAttendanceService.DeactivateAsync(new DeactivateOfficeAttendanceRequestDto { Id = id }));
    }
}
