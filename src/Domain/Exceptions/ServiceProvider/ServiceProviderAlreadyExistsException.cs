namespace Domain.Exceptions.ServiceProvider;

public class ServiceProviderAlreadyExistsException(string cnpj) 
    : ApiException($"Prestador de serviço com CNPJ {cnpj} já existe", 400);
