namespace Domain.Exceptions.Addresses;
public class AddressNotFoundException(Guid guid)
    : ApiException($"O endereço {guid} não foi encontrado.", 404);