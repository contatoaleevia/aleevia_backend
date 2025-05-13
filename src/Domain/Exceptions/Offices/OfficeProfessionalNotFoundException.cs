namespace Domain.Exceptions.Offices;

public class OfficeProfessionalNotFoundException(Guid id) : NotFoundException($"Vínculo entre local de atendimento e profissional não encontrado: {id}")
{
} 