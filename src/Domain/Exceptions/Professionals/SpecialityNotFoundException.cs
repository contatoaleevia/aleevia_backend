namespace Domain.Exceptions.Professionals;

public class SpecialityNotFoundException(Guid id) : Exception($"Especialidade com ID {id} não encontrada."); 