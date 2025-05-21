using Application.DTOs.IaChats.CreateIaChatDTOs;
using Application.DTOs.IaChats.CreateIaMessageDTOs;
using Application.DTOs.IaChats.CreateIaChatRatingDTOs;
using Application.Services.IaChats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/chats")]
public class IaChatController(IIaChatService iaChatService, IIaChatRatingService iaChatRatingService) : ControllerBase
{
    /// <summary>
    /// Obtém todos os chats disponíveis.
    /// </summary>
    /// <returns>Lista de todos os chats</returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllChats()
    {
        return Ok(await iaChatService.GetAllChatsAsync());
    }

    /// <summary>
    /// Cria um chat de IA.
    /// </summary>
    /// <param name="requestDto">Objeto com os dados para criação do chat:
    /// <summary/>SourceHash: Hash para personalizar o chat.
    /// </param>
    /// <returns>Informações do chat criado</returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateChat([FromForm] CreateIaChatRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await iaChatService.CreateChatAsync(requestDto);
        return Ok(response);
    }

    /// <summary>
    /// Obtém todas as mensagens de um chat específico.
    /// </summary>
    /// <param name="chatId">ID do chat para buscar as mensagens</param>
    /// <returns>Lista de mensagens do chat</returns>
    [HttpGet("{chatId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetChatMessages(Guid chatId)
    {
        return Ok(await iaChatService.GetChatMessagesAsync(chatId));
    }

    /// <summary>
    /// Adiciona uma nova mensagem a um chat existente.
    /// </summary>
    /// <param name="chatId">ID do chat para adicionar a mensagem</param>
    /// <param name="requestDto">Objeto com os dados da mensagem:
    /// <summary/>Content: Conteúdo da mensagem
    /// <summary/>Role: Papel do remetente (user, assistant, system)
    /// </param>
    /// <returns>Informações da mensagem adicionada</returns>
    [HttpPost("{chatId:guid}/messages")]
    [AllowAnonymous]
    public async Task<IActionResult> AddMessageToChat(Guid chatId, [FromBody] CreateIaMessageRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await iaChatService.AddMessageToChatAsync(chatId, requestDto);
        return Ok(response);
    }

    /// <summary>
    /// Adiciona uma avaliação a um chat existente.
    /// </summary>
    /// <param name="chatId">ID do chat para avaliar</param>
    /// <param name="requestDto">Objeto com os dados da avaliação:
    /// <summary/>GeneralRating: Avaliação geral (0-10)
    /// <summary/>Experience: Experiência (0 Muito boa, 1 Boa, 2 Regular, 3 Ruim, 4 Muito ruim) 
    /// <summary/>Utility: Utilidade (1-5)
    /// <summary/>ProblemSolved: Problema resolvido (0 Sim, 1 Parcialmente, 2 Não)
    /// <summary/>Comment: Comentário (opcional)
    /// </param>
    /// <returns>Informações da avaliação adicionada</returns>
    [HttpPost("{chatId:guid}/rating")]
    [AllowAnonymous]
    public async Task<IActionResult> RateChat(Guid chatId, [FromBody] CreateIaChatRatingRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await iaChatRatingService.CreateRatingAsync(chatId, requestDto);
        return Ok(response);
    }
} 
