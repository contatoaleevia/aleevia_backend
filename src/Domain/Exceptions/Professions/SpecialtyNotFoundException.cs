namespace Domain.Exceptions.Professions;

public class SpecialtyNotFoundException(Guid specialtyId) 
    : ApiException($"Especialidade com id {specialtyId} não encontrada", 404);
