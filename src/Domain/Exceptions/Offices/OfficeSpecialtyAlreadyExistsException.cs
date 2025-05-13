namespace Domain.Exceptions.Offices;

public class OfficeSpecialtyAlreadyExistsException(Guid officeId, Guid specialtyId) : Exception($"Especialidade {specialtyId} já vinculada ao local de atendimento {officeId}")
{
} 