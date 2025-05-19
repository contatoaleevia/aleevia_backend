using Application.DTOs.ServiceTypes.CreateServiceTypeDTOs;
using Application.DTOs.ServiceTypes.DeactivateServiceTypeDTOs;
using Application.Services.ServiceTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.ApiResponses;
namespace Api.Controllers;

[Route("api/service-type")]
public class ServiceTypeController(IServiceTypeService serviceTypeService) : ControllerBase
{
    /// <summary>
    /// Obtém todos os tipos de serviço ativos.
    /// </summary>
    /// <returns>Lista de todos os tipos de serviço</returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await serviceTypeService.GetAllAsync());
    }

    /// <summary>
    /// Cria um novo tipo de serviço.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados do tipo de serviço
    /// <summary/>Name: Nome do tipo de serviço
    /// <summary/>Description: Descrição do tipo de serviço (opcional)
    /// </param>
    /// <returns>Informações do tipo de serviço criado</returns>
    [HttpPost]
    [AllowAnonymous]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreateServiceTypeResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateServiceTypeRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(await serviceTypeService.CreateAsync(requestDto));
    }

    /// <summary>
    /// Desativa um tipo de serviço existente.
    /// </summary>
    /// <param name="id">ID do tipo de serviço a ser desativado</param>
    /// <returns>Confirmação da desativação do tipo de serviço</returns>
    [HttpDelete("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Deactivate([FromRoute] Guid id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(await serviceTypeService.DeactivateAsync(new DeactivateServiceTypeRequestDto { Id = id }));
    }
}