using Api.ApiResponses;
using Application.DTOs.ServiceProviders.CreateServiceProviderDTOs;
using Application.DTOs.ServiceProviders.GetServiceProviderDTOs;
using Application.DTOs.ServiceProviders.DeactivateServiceProviderDTOs;
using Application.DTOs.ServiceProviders.UpdateServiceProviderDTOs;
using Application.Services.ServiceProviders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/service-provider")]
public class ServiceProviderController(IServiceProviderService service) : ControllerBase
{
    /// <summary>
    /// Cria um novo prestador de serviço.
    /// </summary>
    /// <param name="request">Objeto com os dados do prestador de serviço:
    /// <summary/>Cnpj: CNPJ do prestador de serviço
    /// <summary/>Name: Nome do prestador de serviço
    /// <summary/>CorporateName: Razão social do prestador de serviço
    /// <summary/>OfficeId: ID da unidade
    /// </param>
    /// <returns>Dados do prestador de serviço criado</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(CreateServiceProviderResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateServiceProvider([FromBody] CreateServiceProviderRequestDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await service.CreateAsync(request));
    }

    /// <summary>
    /// Obtém todos os prestadores de serviço de uma unidade.
    /// </summary>
    /// <param name="officeId">ID da unidade</param>
    /// <returns>Lista de prestadores de serviço</returns>
    [HttpGet("{officeId:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(List<GetServiceProviderResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllServiceProviders([FromRoute] Guid officeId)
    {
        return Ok(await service.GetAllAsync(officeId));
    }

    /// <summary>
    /// Atualiza um prestador de serviço.
    /// </summary>
    /// <param name="request">Dados para atualização:
    /// <summary/>Name: Novo nome do prestador de serviço
    /// <summary/>CorporateName: Nova razão social do prestador de serviço
    /// </param>
    /// <returns>Dados atualizados do prestador de serviço</returns>
    [HttpPatch]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(UpdateServiceProviderResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateServiceProvider([FromBody] UpdateServiceProviderRequestDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await service.UpdateAsync(request));
    }

    /// <summary>
    /// Desativa um prestador de serviço.
    /// </summary>
    /// <param name="id">ID do prestador de serviço a ser desativado</param>
    /// <returns>Confirmação da desativação do prestador de serviço</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeactivateServiceProvider([FromRoute] Guid id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await service.DeactivateAsync(new DeactivateServiceProviderRequestDto { Id = id }));
    }

    /// <summary>
    /// Busca prestadores de serviço por nome ou CNPJ.
    /// </summary>
    /// <param name="filter">Filtro contendo nome ou CNPJ do prestador:
    /// <summary/>Name: Nome do prestador de serviço
    /// <summary/>Cnpj: CNPJ do prestador de serviço
    /// </param>
    /// <returns>Lista de prestadores de serviço que correspondem ao filtro</returns>
    [HttpGet("search")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(List<GetServiceProviderResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SearchServiceProviders([FromQuery] GetServiceProviderByFilterRequestDto filter)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        return Ok(await service.SearchAsync(filter));
    }
} 