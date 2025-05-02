namespace Domain.Exceptions;

public class OfficeServiceAlreadyChainedException(Guid officeId, Guid serviceTypeId)
    : ApiException($"O serviço com ID {serviceTypeId} já está vinculado ao local de atendimento com ID {officeId}", 400); 