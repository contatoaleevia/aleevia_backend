using Domain.Entities.Offices;

namespace Application.DTOs.Offices.GetOfficeAnalyticsDTOs;

public record GetOfficeAnalyticsResponse
{
    public required OfficeAnalyticsData Analytics { get; init; }

    public static GetOfficeAnalyticsResponse FromOffice(
        Office office,
        int totalProfessionals,
        int totalServices,
        int totalFaqs,
        int totalHealthCares)
    {
        ArgumentNullException.ThrowIfNull(office);

        return new GetOfficeAnalyticsResponse
        {
            Analytics = new OfficeAnalyticsData
            {
                OfficeId = office.Id,
                OfficeName = office.Name,
                TotalProfessionals = totalProfessionals,
                TotalServices = totalServices,
                TotalFaqs = totalFaqs,
                TotalHealthCares = totalHealthCares
            }
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