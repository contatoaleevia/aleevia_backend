namespace Domain.Exceptions;

public class LeadAlreadyExistException()
    : ApiException($"Já existe um lead cadastrado com este CPF ou E-mail.", 400);
