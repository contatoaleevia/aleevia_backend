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
    /// <param name="requestDto">Objeto com os dados para criação do FAQ</param>
    /// <param name="requestDto.Question">Pergunta do FAQ</param>
    /// <param name="requestDto.Answer">Resposta do FAQ</param>
    /// <param name="requestDto.SourceId">ID da fonte (profissional) relacionada ao FAQ</param>
    /// <returns>Informações do FAQ criado</returns>
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
    /// <param name="id">ID do profissional para buscar os FAQs relacionados</param>
    /// <returns>Lista de FAQs do profissional</returns>
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(GetFaqByProfessionalIdResponseDtoList), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetFaqsBySourceId(Guid id)
    {
        return Ok(await faqService.GetFaqsBySourceIdAsync(id));
    }

    /// <summary>
    /// Busca FAQs por URL personalizada.
    /// </summary>
    /// <param name="customUrl">URL personalizada para buscar os FAQs</param>
    /// <returns>Lista de FAQs associados à URL personalizada</returns>
    [HttpGet("url/{customUrl}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFaqsByCustomUrl(string customUrl)
    {
        var response = await faqService.GetFaqsByCustomUrlAsync(customUrl);
        return Ok(response);
    }

    /// <summary>
    /// Busca uma página de FAQ pelo ID da fonte.
    /// </summary>
    /// <param name="sourceId">ID da fonte (profissional) para buscar a página de FAQ</param>
    /// <returns>Página de FAQ relacionada à fonte</returns>
    [HttpGet("page/{sourceId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetFaqPage(Guid sourceId)
    {
        var response = await faqPageService.GetFaqPageBySourceIdAsync(sourceId);
        return Ok(response);
    }

    /// <summary>
    /// Cria uma página de FAQ.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados para criação da página</param>
    /// <param name="requestDto.Title">Título da página de FAQ</param>
    /// <param name="requestDto.Description">Descrição da página de FAQ</param>
    /// <param name="requestDto.SourceId">ID da fonte (profissional, local de trabalho) relacionada à página</param>
    /// <param name="requestDto.CustomUrl">URL personalizada para a página (opcional)</param>
    /// <returns>Informações da página de FAQ criada</returns>
    [HttpPost("page")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateFaqPage([FromBody] CreateFaqPageRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqPageService.CreateFaqPageAsync(requestDto);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza uma página de FAQ.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados para atualização da página</param>
    /// <param name="requestDto.Id">ID da página de FAQ a ser atualizada</param>
    /// <param name="requestDto.Title">Novo título da página de FAQ (opcional)</param>
    /// <param name="requestDto.Description">Nova descrição da página de FAQ (opcional)</param>
    /// <param name="requestDto.CustomUrl">Nova URL personalizada para a página (opcional)</param>
    /// <returns>Informações da página de FAQ atualizada</returns>
    [HttpPatch("page")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateFaqPage([FromBody] UpdateFaqPageRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await faqPageService.UpdateFaqPageAsync(requestDto);
        return Ok(response);
    }

    /// <summary>
    /// Edita um FAQ existente.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados para atualização do FAQ</param>
    /// <param name="requestDto.Id">ID do FAQ a ser atualizado</param>
    /// <param name="requestDto.Question">Nova pergunta do FAQ (opcional)</param>
    /// <param name="requestDto.Answer">Nova resposta do FAQ (opcional)</param>
    /// <returns>Informações do FAQ atualizado</returns>
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
    /// <param name="requestDto">Objeto com os dados para exclusão do FAQ</param>
    /// <param name="requestDto.Id">ID do FAQ a ser excluído</param>
    /// <returns>Confirmação da exclusão do FAQ</returns>
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