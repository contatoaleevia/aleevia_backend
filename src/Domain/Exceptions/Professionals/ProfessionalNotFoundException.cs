namespace Domain.Exceptions.Professionals;
public class ProfessionalNotFoundException(string guid)
: ApiException($"Profissional para o usuário: {guid} não encontrado", 404);