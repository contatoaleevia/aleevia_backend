namespace Domain.Exceptions;

public class CpfNotValidException(string cpf)
    : ApiException($"Cpf: {cpf} não é válido", 400);
