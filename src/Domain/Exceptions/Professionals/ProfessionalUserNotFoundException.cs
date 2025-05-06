namespace Domain.Exceptions.Professionals;
public class ProfessionalUserNotFoundException(string cpf)
: ApiException($"Usuário com cpf: {cpf} não encontrado", 404);