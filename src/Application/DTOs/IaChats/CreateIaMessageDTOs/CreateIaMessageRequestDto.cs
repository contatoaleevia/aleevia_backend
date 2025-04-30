namespace Application.DTOs.IaChats.CreateIaMessageDTOs;

public class CreateIaMessageRequestDto
{
    public ushort SenderType { get; set; }
    public string Message { get; set; }
    public string Content { get; set; }

    public CreateIaMessageRequestDto(ushort senderType, string message, string content)
    {
        SenderType = senderType;
        Message = message;
        Content = content;
    }
} 