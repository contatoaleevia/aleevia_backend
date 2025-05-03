using Application.DTOs.IaChats.CreateIaChatDTOs;
using Application.DTOs.IaChats.CreateIaMessageDTOs;
using Application.DTOs.IaChats.GetIaChatDTOs;
using Application.DTOs.IaChats.GetIaMessageDTOs;
using CrossCutting.Session;
using Domain.Contracts.Repositories;
using Domain.Entities.IaChats;
using Domain.Entities.IaChats.Enums;
using Domain.Exceptions;
using System.Text.Json;

namespace Application.Services.IaChats;

public class IaChatService(
    IIaChatRepository iaChatRepository,
    IUserSession userSession
) : IIaChatService
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
        string initialMessage = $"Olá, bom te ver de volta, como posso te ajudar hoje?";
        var chat = new IaChat(userSession.UserId, userSession.UserType ?? (ushort)IaChatSourceEnum.Lead);

        var message = new IaMessage(
            chat.Id,
            (ushort)IaMessageSenderEnum.Ia,
            initialMessage,
            string.Empty
        );
        chat.Messages.Add(message);
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
        var chat = await iaChatRepository.GetByIdWithMessagesAsync(chatId) ?? throw new ChatNotFoundException(chatId);

        var userInfo = new Dictionary<string, object?>
        {
            ["user_id"] = null,
            ["preferred_name"] = null,
            ["phone_number"] = null,
            ["birth_date"] = null
        };

        if (userSession.IsAuthenticated())
        {
            var userId = userSession.UserId;
            if (userId != Guid.Empty)
            {
                userInfo["user_id"] = userId;
                userInfo["preferred_name"] = userSession.Email; // Using email as we don't have preferred name
            }
        }

        var userMessage = new IaMessage(
            chatId,
            (ushort)IaMessageSenderEnum.Client,
            requestDto.Message,
            requestDto.Content
        );
        chat.Messages.Add(userMessage);

        var initialState = new Dictionary<string, object?>
        {
            ["user_id"] = userInfo["user_id"],
            ["name"] = userInfo["preferred_name"],
            ["phone_number"] = userInfo["phone_number"],
            ["birth_date"] = userInfo["birth_date"],
            ["available_appointments"] = null
        };


        //TODO: Call AI ON PYTHON

        // var (aiResponseContent, appointmentData) = await GenerateAiResponseAsync(
        //     initialState,
        //     [.. chat.Messages.OrderBy(m => m.CreatedAt)],
        //     requestDto.Message
        // );

        var aiMessage = new IaMessage(
            chatId,
            (ushort)IaMessageSenderEnum.Ia,
            "Resposta da IA",
            JsonSerializer.Serialize(new { appointment_options = "appointmentData" })
        );
        chat.Messages.Add(aiMessage);

        await iaChatRepository.UpdateAsync(chat);

        return new CreateIaMessageResponseDto
        {
            Id = aiMessage.Id,
            IaChatId = aiMessage.IaChatId,
            SenderType = aiMessage.SenderType.SenderTypeName,
            Message = aiMessage.Message,
            Content = aiMessage.Content,
            CreatedAt = aiMessage.CreatedAt
        };
    }
} 