namespace Domain.Exceptions.Professionals;
public class ProfessionalAlreadyRegisteredException(string guid)
    : ApiException($"Profissional para o usuário: {guid} já está registrado", 400);