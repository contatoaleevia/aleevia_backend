namespace Domain.Exceptions.Professionals;
    public class ProfessionalAlreadyExistsException(string cpf)
    : ApiException($"O Profissional para o CPF: {cpf} já existe", 400);