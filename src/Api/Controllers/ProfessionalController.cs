﻿using Api.ApiResponses;
using Application.DTOs.Professionals.GetProfessionalDTOs;
using Application.Services.Professionals;
using CrossCutting.Session;
using Domain.Contracts.Services.RegisterProfessionals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/professional")]
public class ProfessionalController(IProfessionalService service, IUserSession session) : ControllerBase
{
    /// <summary>
    /// Cria um novo Profissional de Saúde.
    /// </summary>
    /// <param name="request">Objeto com os dados do profissional:
    /// <summary/>Name: Nome completo do profissional
    /// <summary/>Email: Email do profissional
    /// <summary/>Document: Documento do profissional (CPF)
    /// <summary/>PhoneNumber: Número de telefone do profissional
    /// <summary/>Specialty: Especialidade do profissional
    /// <summary/>RegisterNumber: Número de registro profissional (CRM, CRO, etc.)
    /// <summary/>RegisterState: Estado do registro profissional (UF)
    /// </param>
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

    /// <summary>
    /// Obtém os dados do profissional logado.
    /// </summary>
    /// <returns>Dados completos do profissional</returns>
    [HttpGet("me")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(GetProfessionalResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMyProfile()
    {
        return Ok(await service.GetProfessionalByUserId(session.UserId));
    }
}
