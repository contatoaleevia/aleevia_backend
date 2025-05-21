using Application.DTOs.Faqs;
using Application.DTOs.IaChats;
using Domain.Entities.Offices;

namespace Application.DTOs.Offices.GetOfficeAnalyticsDTOs;

public class GetOfficeAnalyticsResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Logo { get; set; }
    public int TotalProfessionals { get; set; }
    public int TotalServices { get; set; }
    public FaqStatisticsDto FaqStatistics { get; set; } = new();
    public int TotalHealthCares { get; set; }
    public IaChatRatingStatisticsDto ChatRatingStatistics { get; set; } = new();
    public IaChatStatisticsDto ChatStatistics { get; set; } = new();

    public static GetOfficeAnalyticsResponse FromOffice(
        Office office,
        int totalProfessionals,
        int totalServices,
        FaqStatisticsDto faqStatistics,
        int totalHealthCares,
        IaChatRatingStatisticsDto chatRatingStatistics,
        IaChatStatisticsDto chatStatistics)
    {
        return new GetOfficeAnalyticsResponse
        {
            Id = office.Id,
            Name = office.Name,
            Logo = office.Logo?.Value,
            TotalProfessionals = totalProfessionals,
            TotalServices = totalServices,
            FaqStatistics = faqStatistics,
            TotalHealthCares = totalHealthCares,
            ChatRatingStatistics = chatRatingStatistics,
            ChatStatistics = chatStatistics
        };
    }
}

public record OfficeAnalyticsData
{
    public required Guid OfficeId { get; init; }
    public required string OfficeName { get; init; }
    public required int TotalProfessionals { get; init; }
    public required int TotalServices { get; init; }
    public required int TotalFaqs { get; init; }
    public required int TotalHealthCares { get; init; }
} 