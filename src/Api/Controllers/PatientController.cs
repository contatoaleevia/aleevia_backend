using Api.ApiResponses;
using Api.Attributes;
using Application.DTOs.Patients.CreatePatientDTOs;
using Application.DTOs.Patients.CreatePatientLeadDTOs;
using Application.Services.Patients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/patient")]
public class PatientController(
    IPatientService patientService,
    IPatientLeadService patientLeadService
) : ControllerBase
{
    /// <summary>
    /// Cria um novo paciente no sistema.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ApiKey]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreatePatientResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UnauthorizedResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientRequestDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await patientService.CreatePatientAsync(request));
    }

    /// <summary>
    /// Cria um novo lead de paciente no sistema.
    /// </summary>
    /// <returns></returns>
    [HttpPost("lead")]
    [ApiKey]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreatePatientLeadResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePatientLead([FromBody] CreatePatientLeadRequestDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await patientLeadService.CreatePatientLeadAsync(request));
    }
} 