namespace Domain.Exceptions;

public class CnpjNotValidException(string cnpj) 
    : ApiException($"CNPJ: {cnpj} não é válido", 400);
