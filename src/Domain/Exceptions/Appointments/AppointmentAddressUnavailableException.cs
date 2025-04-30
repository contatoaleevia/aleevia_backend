namespace Domain.Exceptions.Appointments;
public class AppointmentAddressUnavailableException(Guid? addressId)
    : ApiException($"O endereço {addressId} já possui compromisso cadastrado para a data selecionada.", 403);