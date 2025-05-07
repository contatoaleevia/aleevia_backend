namespace Domain.Exceptions;

public class FaqPageBySourceIdNotFoundException : NotFoundException
{
    public FaqPageBySourceIdNotFoundException(Guid sourceId) 
        : base($"Página FAQ não encontrada para a fonte com ID: {sourceId}")
    {
    }
} 