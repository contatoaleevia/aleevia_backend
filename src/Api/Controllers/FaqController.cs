using Api.ApiResponses;
using Application.DTOs.Faqs.CreateFaqDTOs;
using Application.DTOs.Faqs.DeleteFaqDTOs;
using Application.DTOs.Faqs.GetFaqDTOs;
using Application.DTOs.Faqs.UpdateFaqDTOs;
using Application.Services.Faqs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/faq")]
public class FaqController(IFaqService faqService) : ControllerBase
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
    public async Task<IActionResult> GetFaqsByProfessionalId(Guid id)
    {
        return Ok(await faqService.GetFaqsByProfessionalIdAsync(id));
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
    public async Task<IActionResult> DeleteFaq([FromBody] DeleteFaqRequestDto id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqService.DeleteFaqAsync(id);
        return Ok(response);
    }
}