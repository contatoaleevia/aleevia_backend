namespace Domain.Exceptions.ServiceProvider;

public class ServiceProviderNotFoundException(Guid serviceProviderId) 
    : ApiException($"Prestador de serviço com id {serviceProviderId} não encontrado", 404);
