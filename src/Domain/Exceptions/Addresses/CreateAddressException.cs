namespace Domain.Exceptions.Addresses;
public class CreateAddressException(Guid guid)
    : ApiException($"Ocorreu um erro ao criar o endereço: {guid}", 400);