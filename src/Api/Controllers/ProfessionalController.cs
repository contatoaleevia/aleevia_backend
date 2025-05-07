using Api.ApiResponses;
using Application.DTOs.Professionals;
using Application.DTOs.Users.LoginDTOs;
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

    /// <summary>
    /// Vincula um Profissional de Saúde a um Consultório.
    /// </summary>
    /// <returns></returns>
    [HttpPost("bind-office")]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BindProfessionalOffice([FromBody] BindProfessionalOfficeRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await service.BindProfessionalOffice(requestDto);
        return Ok(response);
    }

    /// <summary>
    /// Faz o Pré-cadastro de um Profissional de Saúde.
    /// </summary>
    /// <returns></returns>
    [HttpPost("pre-register")]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PreCreateProfessional([FromBody] PreCreateProfessionalRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await service.PreCreateProfessional(requestDto);
        return Ok(response);
    }
}