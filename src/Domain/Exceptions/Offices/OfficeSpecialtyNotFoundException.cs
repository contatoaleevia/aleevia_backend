namespace Domain.Exceptions.Offices;

public class OfficeSpecialtyNotFoundException(Guid id) : NotFoundException($"Vínculo entre local de atendimento e especialidade não encontrado: {id}"); 