namespace Domain.Exceptions.Professionals;

public class ProfessionalAlreadyRegisteredException(string cpf)
    : ApiException($"Profissional já cadastrado com o CPF: {cpf}", 409);