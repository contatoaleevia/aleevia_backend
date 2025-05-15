namespace Application.DTOs.Faqs.UpdateFaqDTOs;
public class UpdateFaqRequestDto(Guid id, string question, string answer, string? link, ushort faqCategory)
{
    public Guid Id { get; set; } = id;
    public string Question { get; set; } = question;
    public string Answer { get; set; } = answer;
    public string? Link { get; set; } = link;
    public ushort FaqCategory { get; set; } = faqCategory;
}