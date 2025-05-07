namespace Domain.Exceptions;

public class FaqNotFoundException(Guid id)
    : ApiException($"FAQ com id: {id} não encontrada", 404);