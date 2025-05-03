using Application.DTOs.IaChats.CreateIaChatDTOs;
using Application.DTOs.IaChats.CreateIaMessageDTOs;
using Application.DTOs.IaChats.GetIaChatDTOs;
using Application.DTOs.IaChats.GetIaMessageDTOs;

namespace Application.Services.IaChats;

public interface IIaChatService
{
    Task<List<GetIaChatResponseDto>> GetAllChatsAsync();
    Task<CreateIaChatResponseDto> CreateChatAsync(CreateIaChatRequestDto requestDto);
    Task<List<GetIaMessageResponseDto>> GetChatMessagesAsync(Guid chatId);
    Task<CreateIaMessageResponseDto> AddMessageToChatAsync(Guid chatId, CreateIaMessageRequestDto requestDto);
} 