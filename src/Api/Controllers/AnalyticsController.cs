using Api.ApiResponses;
using Application.DTOs.Offices.GetOfficeAnalyticsDTOs;
using Application.Services.Analytics;
using CrossCutting.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/analytics")]
public class AnalyticsController(IAnalyticsService analyticsService, IUserSession session) : ControllerBase
{
    /// <summary>
    /// Obtém métricas e análises de um local de trabalho (Office) específico.
    /// </summary>
    /// <param name="officeId">ID do local de trabalho</param>
    /// <returns>Dados analíticos do local de trabalho, incluindo:
    /// - Total de profissionais
    /// - Total de serviços
    /// - Total de FAQs
    /// - Total de convênios
    /// - Estatísticas de avaliações de chat
    /// - Estatísticas de conversas de chat
    /// </returns>
    [HttpGet("office/{officeId:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(GetOfficeAnalyticsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOfficeAnalytics(Guid officeId)
    {
        return Ok(await analyticsService.GetOfficeAnalytics(officeId, session.UserId));
    }
} 