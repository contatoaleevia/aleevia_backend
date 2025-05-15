namespace Application.DTOs.Faqs.ImportFaqsDTOs;
public class ImportFaqsRequest
{
    public string FaqCategory { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string? Link { get; set; }
}