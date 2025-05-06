using Api.ApiResponses;
using Application.DTOs.Offices.BindOfficeAddressDTOs;
using Application.DTOs.Offices.CreateOfficeDTOs;
using Application.DTOs.Offices.DeleteOfficeAddressDTOs;
using Application.Services.Offices;
using CrossCutting.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/office")]
public class OfficeController(IOfficeService service, IUserSession session) : ControllerBase
{
    /// <summary>
    /// Cria um Office. 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateOffice([FromBody] CreateOfficeRequest request)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await service.CreateOffice(request, session.UserId));
    }

    /// <summary>
    /// Vincula um endereço a um Office. 
    /// O endereço deve ser criado previamente.
    /// Caso o AddressId seja vazio, o endereço será considerado como Teleconsulta automaticamente.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BindOfficeAddress([FromBody] BindOfficeAddressRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await service.BindOfficeAddress(request, session.UserId));
    }

    /// <summary>
    /// Deleta um endereço de um Office (soft delete).
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteOfficeAddress([FromBody] DeleteOfficeAddressRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await service.DeleteOfficeAddress(request.Id);
        return Ok();
    }
}