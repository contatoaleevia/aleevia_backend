namespace Domain.Exceptions.Professionals;

public class ProfessionalIdNotFoundException(Guid id) : NotFoundException($"Profissional com id '{id}' não encontrado.")
{
} 