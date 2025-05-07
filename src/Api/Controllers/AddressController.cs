using Api.ApiResponses;
using Application.DTOs.Addresses.CreateAddressDTOs;
using Application.DTOs.Adresses.GetAddressBySourceDTOs;
using Application.DTOs.Adresses.GetAddressDTOs;
using Application.Services;
using Application.Services.Addresses;
using CrossCutting.Session;
using Domain.Exceptions;
using Domain.Exceptions.UserSessions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/address")]
public class AddressController(IAddressService addressService, IUserSession userSession) : ControllerBase
{
    /// <summary>
    /// Busca um endereço pelo Id.
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(GetAddressByIdReponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAddressById(Guid id)
    {
        return Ok(await addressService.GetByIdAddress(id));
    }

    /// <summary>
    /// Cria um Endereço.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(CreateAddressResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAddress([FromBody] CreateAddressRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await addressService.CreateAddressAsync(requestDto);
        return Ok(response);
    }

    /// <summary>
    /// Busca todos os endereços vinculados a um usuário.
    /// </summary>
    /// <returns></returns>
    [HttpGet("by-source")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(IEnumerable<GetAddressBySourceResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAddressBySourceId()
    {
        if (userSession.ManagerId is null)
            return BadRequest(new ManagerIdNotExistsException());
        return Ok(await addressService.GetAddressBySourceId(userSession.UserId, userSession.ManagerId.Value));
    }
}