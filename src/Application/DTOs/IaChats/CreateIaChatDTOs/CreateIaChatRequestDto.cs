namespace Application.DTOs.IaChats.CreateIaChatDTOs;

public class CreateIaChatRequestDto(Guid sourceId, ushort sourceType)
{
    public Guid SourceId { get; set; } = sourceId;
    public ushort SourceType { get; set; } = sourceType;
} 