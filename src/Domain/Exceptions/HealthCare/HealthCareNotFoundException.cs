namespace Domain.Exceptions.HealthCare;

public class HealthCareNotFoundException(Guid id) : Exception($"Convenio com ID {id} não encontrado.")
{
} 