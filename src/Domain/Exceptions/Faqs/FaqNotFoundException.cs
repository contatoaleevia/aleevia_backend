namespace Domain.Exceptions.Faqs;

public class FaqNotFoundException(Guid id)
    : ApiException($"FAQ com id: {id} não encontrada", 404);