namespace Domain.Exceptions;

public class CreatePatientException(Guid userId)
    : ApiException($"Ocorreu um erro ao criar o paciente para o usuário id: {userId}", 400);
