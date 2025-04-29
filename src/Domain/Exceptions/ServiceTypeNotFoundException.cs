namespace Domain.Exceptions;

public class ServiceTypeNotFoundException(Guid id)
    : ApiException($"Tipo de serviço com ID: {id} não encontrado", 404);