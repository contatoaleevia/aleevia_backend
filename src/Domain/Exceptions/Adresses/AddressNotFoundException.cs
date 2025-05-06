namespace Domain.Exceptions.Adresses;
    public class AddressNotFoundException(Guid addressId)
    : ApiException($"Endereço com id {addressId} não encontrado", 404);