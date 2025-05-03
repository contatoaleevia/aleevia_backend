namespace Domain.Exceptions;

public class ChatNotFoundException(Guid chatId) 
    : ApiException($"Chat com id {chatId} não encontrado", 404);
