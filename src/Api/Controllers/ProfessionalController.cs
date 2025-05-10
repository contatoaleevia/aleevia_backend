using Api.ApiResponses;
using Application.Services.Professionals;
using Domain.Contracts.Services.RegisterProfessionals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/professional")]
public class ProfessionalController(IProfessionalService service) : ControllerBase
{
    /// <summary>
    /// Cria um novo Profissional de Saúde.
    /// </summary>
    /// <param name="request">Objeto com os dados do profissional</param>
    /// <param name="request.Name">Nome completo do profissional</param>
    /// <param name="request.Email">Email do profissional</param>
    /// <param name="request.Document">Documento do profissional (CPF)</param>
    /// <param name="request.PhoneNumber">Número de telefone do profissional</param>
    /// <param name="request.Specialty">Especialidade do profissional</param>
    /// <param name="request.RegisterNumber">Número de registro profissional (CRM, CRO, etc.)</param>
    /// <param name="request.RegisterState">Estado do registro profissional (UF)</param>
    /// <returns>ID do profissional criado</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateProfessional([FromBody] RegisterProfessionalRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await service.RegisterProfessional(request);
        return Ok(response);
    }
}