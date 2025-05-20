namespace Application.DTOs.Faqs;

public class FaqStatisticsDto
{
    public int TotalFaqs { get; set; }
    public List<FaqCategoryCountDto> TopCategories { get; set; } = [];
}

public class FaqCategoryCountDto
{
    public string Category { get; set; } = string.Empty;
    public int Count { get; set; }
} 