namespace Domain.Exceptions.Offices;
    public class OfficeAddressAlreadyExistsException(Guid officeId)
    : ApiException($"Já existe endereço cadastrado para o local: {officeId}", 400);