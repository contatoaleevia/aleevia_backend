namespace Domain.Exceptions.Appointments;
public class AppointmentNotFoundException(Guid guid)
    : ApiException($"O compromisso {guid} não foi encontrado.", 404);