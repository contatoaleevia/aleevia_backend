using Api.ApiResponses;
using Api.Attributes;
using Application.DTOs.Patients.CreatePatientDTOs;
using Application.DTOs.Patients.CreatePatientLeadDTOs;
using Application.Services.Patients;
using Application.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/patient")]
public class PatientController(
    IPatientLeadService patientLeadService,
    IUserService userService
) : ControllerBase
{
    /// <summary>
    /// Cria um novo paciente no sistema.
    /// </summary>
    /// <param name="request">Objeto com os dados do paciente:
    /// <summary/>Name: Nome completo do paciente
    /// <summary/>Email: Email do paciente
    /// <summary/>Document: Documento do paciente (CPF)
    /// <summary/>PhoneNumber: Número de telefone do paciente
    /// <summary/>Password: Senha para acesso ao sistema
    /// <summary/>BirthDate: Data de nascimento do paciente
    /// </param>
    /// <returns>Informações do paciente criado</returns>
    [HttpPost]
    [ApiKey]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreatePatientUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePatient([FromBody] CreatePatientUserRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await userService.CreatePatientUserAsync(request));
    }

    /// <summary>
    /// Cria um novo lead de paciente no sistema.
    /// Um lead é um registro inicial de um potencial paciente.
    /// </summary>
    /// <param name="request">Objeto com os dados do lead de paciente:
    /// <summary/>Name: Nome do lead
    /// <summary/>Email: Email de contato do lead
    /// <summary/>PhoneNumber: Número de telefone do lead
    /// <summary/>Message: Mensagem ou informação adicional do lead (opcional)
    /// <summary/>SourceId: ID da fonte ou origem do lead (opcional)
    /// </param>
    /// <returns>Informações do lead de paciente criado</returns>
    [HttpPost("lead")]
    [ApiKey]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreatePatientLeadResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePatientLead([FromBody] CreatePatientLeadRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await patientLeadService.CreatePatientLeadAsync(request));
    }
}
