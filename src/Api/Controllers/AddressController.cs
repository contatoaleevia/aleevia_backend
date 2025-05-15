using Api.ApiResponses;
using Api.Attributes;
using Application.DTOs.Addresses.CreateAddressDTOs;
using Application.DTOs.Addresses.GetAddressDTOs;
using Application.DTOs.Addresses.UpdateAddressDTOs;
using Application.DTOs.Adresses.GetAddressBySourceDTOs;
using Application.Services.Addresses;
using CrossCutting.Session;
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
    /// <param name="id">ID do endereço a ser consultado</param>
    /// <returns>Dados do endereço solicitado</returns>
    [HttpGet("{id:guid}")]
    [ApiKey]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(GetAddressByIdResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAddressById(Guid id)
        => Ok(await addressService.GetByIdAddress(id));

    /// <summary>
    /// Cria um Endereço vinculado ao usuário logado.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados do endereço</param>
    /// <summary/>Street: Nome da rua
    /// <summary/>Number: Número do endereço
    /// <summary/>Complement: Complemento (opcional)
    /// <summary/>Neighborhood: Bairro
    /// <summary/>City: Cidade
    /// <summary/>State: Estado (UF)
    /// <summary/>ZipCode: CEP
    /// <summary/>Country: País
    /// <returns>Informações do endereço criado</returns>
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
    /// Busca todos os endereços vinculados ao usuário logado.
    /// </summary>
    /// <returns>Lista de endereços vinculados ao usuário</returns>
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

    /// <summary>
    /// Atualiza um endereço existente.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados do endereço a ser atualizado</param>
    /// <summary/>Id: ID do endereço a ser atualizado
    /// <summary/>Name: Nome do endereço
    /// <summary/>Street: Nome da rua
    /// <summary/>Number: Número do endereço
    /// <summary/>Complement: Complemento (opcional)
    /// <summary/>Neighborhood: Bairro
    /// <summary/>City: Cidade
    /// <returns>Informações do endereço atualizado</returns>
    [HttpPatch]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(UpdateAddressResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAddress([FromBody] UpdateAddressRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await addressService.UpdateAddressAsync(requestDto);
        return Ok(response);
    }
}