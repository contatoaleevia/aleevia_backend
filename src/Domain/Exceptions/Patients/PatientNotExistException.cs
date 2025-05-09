namespace Domain.Exceptions;

public class PatientNotExistException(Guid userId)
    : ApiException($"Paciente com UserId: {userId} não encontrado", 404);