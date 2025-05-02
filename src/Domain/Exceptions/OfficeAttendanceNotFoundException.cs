namespace Domain.Exceptions;

public class OfficeAttendanceNotFoundException(Guid id)
    : ApiException($"Serviço de atendimento com ID: {id} não encontrado", 404); 