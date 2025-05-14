namespace Application.DTOs.Faqs.UpdateFaqDTOs;
public class UpdateFaqRequestDto(Guid id, string question, string answer, ushort faqCategory)
{
    public Guid Id { get; set; } = id;
    public string Question { get; set; } = question;
    public string Answer { get; set; } = answer;
    public ushort FaqCategory { get; set; } = faqCategory;
}