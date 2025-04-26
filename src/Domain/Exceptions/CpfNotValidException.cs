namespace Domain.Exceptions;

public class CpfNotValidException(string cpf)
    : ApiException($"Cpf: {cpf} is not valid", 400);
