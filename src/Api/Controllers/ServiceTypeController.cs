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

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await serviceTypeService.GetAllAsync());
    }

    [HttpPost]
    [AllowAnonymous]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CreateServiceTypeResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UnauthorizedResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateServiceTypeRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(await serviceTypeService.CreateAsync(requestDto));
    }

    [HttpDelete("{id:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Deactivate([FromRoute] Guid id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(await serviceTypeService.DeactivateAsync(new DeactivateServiceTypeRequestDto { Id = id }));
    }
} 