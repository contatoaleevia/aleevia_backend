namespace Application.DTOs.IaChats.CreateIaChatDTOs;

public class CreateIaChatRequestDto
{
    public Guid SourceId { get; set; }
    public ushort SourceType { get; set; }

    public CreateIaChatRequestDto(Guid sourceId, ushort sourceType)
    {
        SourceId = sourceId;
        SourceType = sourceType;
    }
} 