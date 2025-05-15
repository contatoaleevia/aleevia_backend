using Api.ApiResponses;
using Application.DTOs.HealthCares.CreateHealthCareDTOs;
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
    /// Create a new healthcare
    /// </summary>
    /// <param name="requestDto"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CreateHealthCareResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateHealthCare([FromBody] CreateHealthCareRequest requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await healthCareService.CreateHealthCareAsync(requestDto);
        return Ok(response);
    }
}