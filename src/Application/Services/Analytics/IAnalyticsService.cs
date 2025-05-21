using Application.DTOs.Offices.GetOfficeAnalyticsDTOs;

namespace Application.Services.Analytics;

public interface IAnalyticsService
{
    Task<GetOfficeAnalyticsResponse> GetOfficeAnalytics(Guid officeId, Guid userId);
} 