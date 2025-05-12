namespace Domain.Exceptions;

public class FaqPageNotFoundException(Guid id)
    : ApiException($"Página de FAQ com id: {id} não encontrada", 404);