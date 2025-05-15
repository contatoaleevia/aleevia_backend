using Api.ApiResponses;
using Application.DTOs.HealthCares.CreateHealthCareDTOs;
using Application.DTOs.HealthCares.GetHealthCareDTOs;
using Application.DTOs.HealthCares.UpdateHealthCareDTOs;
using Application.Services.HealthCares;
using CrossCutting.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Authorize]
[Route("api/healthcare")]
public class HealthCareController(IHealthCareService healthCareService) : ControllerBase
{
    /// <summary>
    /// Criar um novo convenio de saúde
    /// </summary>
    /// <param name="requestDto">
    /// <summary/>OfficeId: ID do consultório
    /// <summary/>Name: Nome do convenio de saúde
    /// <summary/>AnsNumber: Número do ANS (opcional)
    /// <summary/>Registry: Número de registro do convenio de saúde (opcional)
    /// <summary/>IsActive: Se o convenio de saúde está ativo (true ou false)
    /// </param>
    /// <returns>Informações do convenio de saúde criado</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(CreateHealthCareResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateHealthCare([FromBody] CreateHealthCareRequest requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await healthCareService.CreateHealthCareAsync(requestDto);
        return Ok(response);
    }

    /// <summary>
    /// Obtém todos os convenios de saúde de um consultório específico
    /// </summary>
    /// <param name="officeId">ID do consultório</param>
    /// <returns>Lista de convenios de saúde do consultório</returns>
    [HttpGet("office/{officeId:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(List<GetHealthCareResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetHealthCaresByOfficeId(Guid officeId)
    {
        var response = await healthCareService.GetHealthCaresByOfficeIdAsync(officeId);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza um convenio de saúde
    /// </summary>
    /// <param name="requestDto">
    /// <summary/>Id: ID do convenio de saúde
    /// <summary/>Name: Nome do convenio de saúde
    /// <summary/>AnsNumber: Número do ANS (opcional)
    /// <summary/>Registry: Número de registro do convenio de saúde (opcional)
    /// <summary/>IsActive: Se o convenio de saúde está ativo (true ou false)
    /// </param>
    /// <returns></returns>
    [HttpPatch]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(UpdateHealthCareResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateHealthCare([FromBody] UpdateHealthCareRequest requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await healthCareService.UpdateHealthCareAsync(requestDto);
        return Ok(response);
    }
}