using Application.DTOs.IaChats.CreateIaChatDTOs;
using Application.DTOs.IaChats.CreateIaMessageDTOs;
using Application.DTOs.IaChats.GetIaChatDTOs;
using Application.DTOs.IaChats.GetIaMessageDTOs;
using CrossCutting.Session;
using CrossCutting.Databases;
using Domain.Contracts.Repositories;
using Domain.Entities.IaChats;
using Domain.Entities.IaChats.Enums;
using Domain.Exceptions;
using Domain.Exceptions.Faq;
using Infrastructure.Helpers;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
namespace Application.Services.IaChats;

public class IaChatService(
    IIaChatRepository iaChatRepository,
    IFaqPageRepository faqPageRepository,
    IUserSession userSession,
    IConfiguration configuration,
    IHttpClientFactory httpClientFactory
) : IIaChatService
{
    private readonly string _aiPythonUrl = configuration.GetValue<string>("AiPythonUrl") ?? throw new InvalidOperationException("AiPythonUrl não configurada no appsettings");

    public async Task<List<GetIaChatResponseDto>> GetAllChatsAsync()
    {
        var chats = await iaChatRepository.GetAllAsync();
        return [.. chats.Select(chat => new GetIaChatResponseDto
        {
            Id = chat.Id,
            SourceId = chat.SourceId,
            SourceType = chat.SourceType.SourceTypeName,
            CreatedAt = chat.CreatedAt
        })];
    }

    public async Task<CreateIaChatResponseDto> CreateChatAsync(CreateIaChatRequestDto requestDto)
    {
        var initialMessage = "Olá, como posso te ajudar hoje?";
        var messageContent = new
        {
            source_id = (Guid?)null,
            source_type = (ushort?)null
        };

        if (!string.IsNullOrEmpty(requestDto.SourceHash))
        {
            var (sourceId, sourceType) = HashHelper.DecodeSourceInfo(requestDto.SourceHash);

            var faqPage = await faqPageRepository.GetBySourceIdAsync(sourceId) 
                ?? throw new FaqPageBySourceIdNotFoundException(sourceId);
            initialMessage = faqPage.WelcomeMessage ?? initialMessage;

            messageContent = new
            {
                source_id = (Guid?)sourceId,
                source_type = (ushort?)sourceType
            };
        }

        var userId = userSession.UserId != Guid.Empty ? (Guid?)userSession.UserId : null;
        var chat = new IaChat(userId, userSession.UserType ?? (ushort)IaChatSourceEnum.Lead);

        var message = new IaMessage(
            chat.Id,
            (ushort)IaMessageSenderEnum.Ia,
            initialMessage,
            JsonSerializer.Serialize(messageContent)
        );
        
        chat.Messages.Add(message);
        await iaChatRepository.CreateAsync(chat);

        return new CreateIaChatResponseDto
        {
            Id = chat.Id,
            SourceId = chat.SourceId,
            SourceType = chat.SourceType.SourceTypeName,
            CreatedAt = chat.CreatedAt,
            Message = message.Message
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
            Content = JsonDocument.Parse(message.Content),
            CreatedAt = message.CreatedAt
        }).OrderBy(x => x.CreatedAt)];
    }

    public async Task<CreateIaMessageResponseDto> AddMessageToChatAsync(Guid chatId, CreateIaMessageRequestDto requestDto)
    {
        using var scope = ApiTransactionScope.RepeatableRead(true);

        var chat = await iaChatRepository.GetByIdWithMessagesAsync(chatId) ?? throw new ChatNotFoundException(chatId);
        var userId = userSession.UserId != Guid.Empty ? (Guid?)userSession.UserId : null;

        var lastMessages = chat.Messages
            .OrderByDescending(m => m.CreatedAt)
            .Take(10)
            .OrderBy(m => m.CreatedAt)
            .Select(m => new
            {
                sender_type = m.SenderType.SenderTypeName,
                message = m.Message,
                created_at = m.CreatedAt
            })
            .ToList();

        var requestContent = requestDto.Content != null
            ? JsonSerializer.Deserialize<Dictionary<string, object?>>(requestDto.Content.RootElement.ToString())
            : [];

        var messageContent = requestContent != null 
            ? new Dictionary<string, object?>(requestContent)
            : [];
            
        messageContent["user_id"] = userId;
        messageContent["message_history"] = lastMessages;

        var userMessage = new IaMessage(
            chatId,
            (ushort)IaMessageSenderEnum.Client,
            requestDto.Message,
            JsonSerializer.Serialize(messageContent)
        );

        using var httpClient = httpClientFactory.CreateClient("AiPython");
        var aiRequestData = new
        {
            message = requestDto.Message,
            message_history = lastMessages,
            content = messageContent
        };

        string aiResponseMessage = "Desculpe, não consegui processar sua mensagem no momento. Por favor, tente novamente mais tarde.";
        try
        {
            var aiResponse = await httpClient.PostAsJsonAsync(_aiPythonUrl, aiRequestData);
            if (aiResponse.IsSuccessStatusCode)
            {
                var aiResponseContent = await aiResponse.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                aiResponseMessage = aiResponseContent?["response"] ?? aiResponseMessage;
            }
        }
        catch (Exception)
        {
        }

        var aiMessage = new IaMessage(
            chatId,
            (ushort)IaMessageSenderEnum.Ia,
            aiResponseMessage,
            JsonSerializer.Serialize(messageContent)
        );

        await iaChatRepository.CreateMessageAsync(userMessage);
        await iaChatRepository.CreateMessageAsync(aiMessage);

        scope.Complete();

        return new CreateIaMessageResponseDto
        {
            Id = aiMessage.Id,
            IaChatId = aiMessage.IaChatId,
            Message = aiMessage.Message,
            Content = JsonDocument.Parse(aiMessage.Content),
            CreatedAt = aiMessage.CreatedAt
        };
    }
} 