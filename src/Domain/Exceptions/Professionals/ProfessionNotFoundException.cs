namespace Domain.Exceptions.Professionals;

public class ProfessionNotFoundException(Guid id) : Exception($"Profissão com ID {id} não encontrada."); 