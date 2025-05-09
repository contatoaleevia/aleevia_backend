namespace Domain.Exceptions.Professionals;
public class ProfessionalWithCpfNotFoundException(string cpf)
: ApiException($"Profissional com CPF: {cpf} não encontrado", 404);