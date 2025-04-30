using Application.DTOs.IaChats.CreateIaChatDTOs;
using Application.DTOs.IaChats.CreateIaMessageDTOs;
using Application.DTOs.IaChats.GetIaChatDTOs;
using Application.DTOs.IaChats.GetIaMessageDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.IaChats;
using Domain.Exceptions;
namespace Application.Services.IaChats;

public class IaChatService(IIaChatRepository iaChatRepository) : IIaChatService
{
    public async Task<List<GetIaChatResponseDto>> GetAllChatsAsync()
    {
        var chats = await iaChatRepository.GetAllAsync();
        return [.. chats.Select(chat => new GetIaChatResponseDto
        {
            Id = chat.Id,
            SourceId = chat.SourceId,
            SourceName = chat.Source.Name,
            SourceType = chat.SourceType.SourceTypeName,
            CreatedAt = chat.CreatedAt
        })];
    }

    public async Task<CreateIaChatResponseDto> CreateChatAsync(CreateIaChatRequestDto requestDto)
    {
        var chat = new IaChat(requestDto.SourceId, requestDto.SourceType);
        await iaChatRepository.CreateAsync(chat);

        return new CreateIaChatResponseDto
        {
            Id = chat.Id,
            SourceId = chat.SourceId,
            SourceType = chat.SourceType.SourceTypeName,
            CreatedAt = chat.CreatedAt
        };
    }

    public async Task<List<GetIaMessageResponseDto>> GetChatMessagesAsync(Guid chatId)
    {
        var chat = await iaChatRepository.GetByIdWithMessagesAsync(chatId) ?? throw new ChatNotFoundException(chatId);

        return [.. chat.Messages.Select(message => new GetIaMessageResponseDto
        {
            Id = message.Id,
            IaChatId = message.IaChatId,
            SenderType = message.SenderType.SenderTypeName,
            Message = message.Message,
            Content = message.Content,
            CreatedAt = message.CreatedAt
        }).OrderBy(x => x.CreatedAt)];
    }

    public async Task<CreateIaMessageResponseDto> AddMessageToChatAsync(Guid chatId, CreateIaMessageRequestDto requestDto)
    {
        var chat = await iaChatRepository.GetByIdAsync(chatId) ?? throw new ChatNotFoundException(chatId);
        var message = new IaMessage(chatId, requestDto.SenderType, requestDto.Message, requestDto.Content);

        chat.Messages.Add(message);
        await iaChatRepository.UpdateAsync(chat);

        return new CreateIaMessageResponseDto
        {
            Id = message.Id,
            IaChatId = message.IaChatId,
            SenderType = message.SenderType.SenderTypeName,
            Message = message.Message,
            Content = message.Content,
            CreatedAt = message.CreatedAt
        };
    }
} 