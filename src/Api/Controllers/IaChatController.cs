using Application.DTOs.IaChats.CreateIaChatDTOs;
using Application.DTOs.IaChats.CreateIaMessageDTOs;
using Application.Services.IaChats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/chats")]
public class IaChatController(IIaChatService iaChatService) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllChats()
    {
        return Ok(await iaChatService.GetAllChatsAsync());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateChat([FromBody] CreateIaChatRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await iaChatService.CreateChatAsync(requestDto);
        return Ok(response);
    }

    [HttpGet("{chatId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetChatMessages(Guid chatId)
    {
        return Ok(await iaChatService.GetChatMessagesAsync(chatId));
    }

    [HttpPost("{chatId:guid}/messages")]
    [AllowAnonymous]
    public async Task<IActionResult> AddMessageToChat(Guid chatId, [FromBody] CreateIaMessageRequestDto requestDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var response = await iaChatService.AddMessageToChatAsync(chatId, requestDto);
        return Ok(response);
    }
} 