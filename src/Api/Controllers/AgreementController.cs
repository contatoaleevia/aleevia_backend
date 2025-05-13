using Api.ApiResponses;
using Application.DTOs.Agreements.CreateAgreementDTOs;
using Application.Services.Agreements;
using Application.Services.Users;
using CrossCutting.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/agreement")]
public class AgreementController(IAgreementService agreementService) : ControllerBase
{
    /// <summary>
    /// Cria um novo Convênio vinculando ao espaço de saúde.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(CreateAgreementResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAgreement([FromBody] CreateAgreementRequest requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await agreementService.CreateAgreementAsync(requestDto);
        return Ok(response);
    }
}