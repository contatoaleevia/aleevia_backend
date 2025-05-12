namespace Domain.Exceptions.Offices;

public class OfficeProfessionalAlreadyExistsException(Guid officeId, Guid professionalId)
    : ApiException($"O profissional {professionalId} já está vinculado ao local de trabalho {officeId}", 409); 