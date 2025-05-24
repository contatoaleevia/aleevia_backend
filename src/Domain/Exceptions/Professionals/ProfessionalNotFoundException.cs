namespace Domain.Exceptions.Professionals;

public class ProfessionalNotFoundException(Guid userId) : NotFoundException($"Profissional com userId '{userId}' não encontrado."); 