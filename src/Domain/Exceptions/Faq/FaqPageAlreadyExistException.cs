namespace Domain.Exceptions.Faq;

public class FaqPageAlreadyExistException(Guid id)
    : ApiException($"Página de FAQ com id: {id} já existe", 400);