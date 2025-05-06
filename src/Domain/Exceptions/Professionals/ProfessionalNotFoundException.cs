namespace Domain.Exceptions.Professionals;
public class ProfessionalNotFoundException(Guid guid)
: ApiException($"Profissional para o usuário: {guid} não encontrado", 404);