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
    [HttpGet("office/{officeId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllByOfficeId(Guid officeId)
    {
        return Ok(await officeAttendanceService.GetAllByOfficeIdAsync(officeId));
    }

    [HttpPost]
    [AllowAnonymous]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreateOfficeAttendanceResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UnauthorizedResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateOfficeAttendanceRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(await officeAttendanceService.CreateAsync(requestDto));
    }

    [HttpDelete("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Deactivate([FromRoute] Guid id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(await officeAttendanceService.DeactivateAsync(new DeactivateOfficeAttendanceRequestDto { Id = id }));
    }
} 