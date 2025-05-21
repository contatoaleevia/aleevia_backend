using Api.ApiResponses;
using Application.DTOs.Faqs.CreateFaqDTOs;
using Application.DTOs.Faqs.CreateFaqPageDTOs;
using Application.DTOs.Faqs.DeleteFaqDTOs;
using Application.DTOs.Faqs.GetFaqDTOs;
using Application.DTOs.Faqs.ImportFaqsDTOs;
using Application.DTOs.Faqs.UpdateFaqDTOs;
using Application.DTOs.Faqs.UpdateFaqPageDTOs;
using Application.Services.Faqs;
using CrossCutting.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/faq")]
public class FaqController(IFaqService faqService, IFaqPageService faqPageService, IUserSession userSession) 
    : ControllerBase
{
    /// <summary>
    /// Cria um FAQ.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados para criação do FAQ:
    /// <summary/>SourceId: ID da fonte (profissional) relacionada ao FAQ
    /// <summary/>SourceType: Tipo de fonte (profissional = 0, local de trabalho = 1)
    /// <summary/>Question: Pergunta do FAQ
    /// <summary/>Answer: Resposta do FAQ
    /// <summary/>Link: Link para um video ou pagina web relacionada ao profissional ou clínica
    /// <summary/>FaqCategory: Categoria do FAQ (Orientações ao cliente = 0, Sobre o profissional = 1, Sobre a clínica = 2)
    /// </param>
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
    /// Cria um link para pagina de FAQ personalizada para o Office ou Professional.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados para criação da página:
    /// <summary/>SourceId: ID da fonte (profissional, office) relacionada à página
    /// <summary/>SourceType: Tipo de fonte (profissional = 0, office = 1)
    /// <summary/>WelcomeMessage: Mensagem de boas-vindas da IA para a página de FAQ
    /// </param>
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
    /// Importa uma lista de FAQs.
    /// Aceita SOMENTE arquivos .csv ou .xlsx.
    /// A coluna Categoria pode ser: Orientações ao cliente, Sobre o profissional ou Sobre a clínica.
    /// Retorna quais registros foram importados e quais não.
    /// </summary>
    /// <returns></returns>
    [HttpPost("import")]
    [Consumes("multipart/form-data")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ImportResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ImportFaqs([FromForm] ImportFaqsFile request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        using var stream = request.Archive.OpenReadStream();
        var response = await faqService.ImportFaqs(stream, request.Archive.FileName, userSession.UserId);
        return Ok(response);
    }

    /// <summary>
    /// Atualiza uma página de FAQ.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados para atualização da página:
    /// <summary/>Id: ID da página de FAQ a ser atualizada
    /// <summary/>WelcomeMessage: Nova mensagem de boas-vindas da IA para a página de FAQ
    /// </param>
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
    /// <param name="requestDto">Objeto com os dados para atualização do FAQ:
    /// <summary/>Id: ID do FAQ a ser atualizado
    /// <summary/>Question: Nova pergunta do FAQ (opcional)
    /// <summary/>Answer: Nova resposta do FAQ (opcional)
    /// <summary/>Link: Novo link do FAQ (opcional)
    /// <summary/>FaqCategory: Nova categoria do FAQ (opcional)
    /// </param>
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
    /// <param name="requestDto">Objeto com os dados para exclusão do FAQ:
    /// <summary/>Id: ID do FAQ a ser excluído
    /// </param>
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
