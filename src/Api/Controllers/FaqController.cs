using Api.ApiResponses;
using Application.DTOs.Faqs.CreateFaqDTOs;
using Application.DTOs.Faqs.CreateFaqPageDTOs;
using Application.DTOs.Faqs.DeleteFaqDTOs;
using Application.DTOs.Faqs.GetFaqDTOs;
using Application.DTOs.Faqs.UpdateFaqDTOs;
using Application.DTOs.Faqs.UpdateFaqPageDTOs;
using Application.Services.Faqs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/faq")]
public class FaqController(IFaqService faqService, IFaqPageService faqPageService) 
    : ControllerBase
{
    /// <summary>
    /// Cria um FAQ.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CreateFaqResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateFaq([FromBody] CreateFaqRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqService.CreateFaqAsync(requestDto);
        return Ok(response);
    }

    /// <summary>
    /// Busca uma lista de FAQs pelo Id do Profissional.
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetFaqByProfessionalIdResponseDtoList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetFaqsBySourceId(Guid id)
    {
        return Ok(await faqService.GetFaqsBySourceIdAsync(id));
    }

    [HttpGet("url/{customUrl}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFaqsByCustomUrl(string customUrl)
    {
        var response = await faqService.GetFaqsByCustomUrlAsync(customUrl);
        return Ok(response);
    }

    [HttpGet("page/{sourceId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFaqPage(Guid sourceId)
    {
        var response = await faqPageService.GetFaqPageBySourceIdAsync(sourceId);
        return Ok(response);
    }

    [HttpPost("page")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateFaqPage([FromBody] CreateFaqPageRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqPageService.CreateFaqPageAsync(requestDto);
        return Ok(response);
    }

    [HttpPatch("page")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateFaqPage([FromBody] UpdateFaqPageRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqPageService.UpdateFaqPageAsync(requestDto);
        return Ok(response);
    }

    /// <summary>
    /// Edita um FAQ.
    /// </summary>
    /// <returns></returns>
    [HttpPatch]
    [AllowAnonymous]
    [ProducesResponseType(typeof(UpdateFaqResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateFaq([FromBody] UpdateFaqRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqService.UpdateFaqAsync(requestDto);
        return Ok(response);
    }

    /// <summary>
    /// Deleta um FAQ.
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    [AllowAnonymous]
    [ProducesResponseType(typeof(DeleteFaqResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteFaq([FromBody] DeleteFaqRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqService.DeleteFaqAsync(requestDto);
        return Ok(response);
    }
}