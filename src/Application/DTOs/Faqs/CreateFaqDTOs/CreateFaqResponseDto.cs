namespace Application.DTOs.Faqs.CreateFaqDTOs;
public class CreateFaqResponseDto(Guid id, string question, string answer, Guid sourceId, DateTime createdAt)
{
    public Guid Id { get; set; } = id;
    public string Question { get; set; } = question;
    public string Answer { get; set; } = answer;
    public Guid SourceId { get; set; } = sourceId;
    public DateTime CreatedAt { get; set; } = createdAt;
}