using Application.DTOs.Faqs;
using Application.DTOs.IaChats;
using Application.DTOs.Offices.GetOfficeAnalyticsDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.IaChats;
using Domain.Exceptions.Managers;
using Domain.Exceptions.Offices;

namespace Application.Services.Analytics;

public class AnalyticsService(
    IOfficeRepository officeRepository,
    IManagerRepository managerRepository,
    IOfficesProfessionalsRepository officesProfessionalsRepository,
    IOfficeAttendanceRepository officeAttendanceRepository,
    IFaqRepository faqRepository,
    IHealthCareRepository healthCareRepository,
    IIaChatRatingRepository iaChatRatingRepository,
    IIaChatRepository iaChatRepository) : IAnalyticsService
{
    public async Task<GetOfficeAnalyticsResponse> GetOfficeAnalytics(Guid officeId, Guid userId)
    {
        var manager = await managerRepository.GetManagerByUserId(userId)
                      ?? throw new ManagerUserNotFoundException(userId);

        var office = await officeRepository.GetByIdAsync(officeId)
                     ?? throw new OfficeNotFoundException(officeId);

        var officeProfessional = await officesProfessionalsRepository.GetByOfficeAndProfessional(officeId, manager.Id);
        if (office.OwnerId != manager.Id && officeProfessional == null)
            throw new UnauthorizedOfficeAccessException(officeId, userId);

        var totalProfessionals = await officesProfessionalsRepository.CountByOfficeIdAsync(officeId);
        var totalServices = await officeAttendanceRepository.CountByOfficeIdAsync(officeId);
        var totalFaqs = await faqRepository.CountBySourceIdAsync(officeId);
        var faqCategories = await faqRepository.GetCategoriesBySourceIdAsync(officeId);
        var totalHealthCares = await healthCareRepository.CountByOfficeIdAsync(officeId);

        var faqStats = new FaqStatisticsDto
        {
            TotalFaqs = totalFaqs,
            TopCategories = [.. faqCategories
                .Select(c => new FaqCategoryCountDto
                {
                    Category = c.Category,
                    Count = c.Count
                })]
        };

        var ratings = await iaChatRatingRepository.GetBySourceIdAsync(officeId);
        var chats = await iaChatRepository.GetBySourceIdAsync(officeId);

        var iaChatRatings = ratings as IaChatRating[] ?? ratings.ToArray();
        var iaChatRatingsLength = iaChatRatings.Length;
        var iaChatRatingsAny = iaChatRatingsLength != 0;
        var chatRatingStats = new IaChatRatingStatisticsDto
        {
            AverageGeneralRating = iaChatRatingsAny ? Math.Round(iaChatRatings.Average(r => r.GeneralRating), 2) : 0,
            AverageExperience = iaChatRatingsAny ? Math.Ceiling(iaChatRatings.Average(r => (int)r.ExperienceType)) : 0,
            AverageUtility = iaChatRatingsAny ? Math.Round(iaChatRatings.Average(r => r.Utility), 2) : 0,
            AverageProblemSolved = iaChatRatingsAny ? Math.Ceiling(iaChatRatings.Average(r => (int)r.ProblemSolvedType)) : 0,
            TotalRatings = iaChatRatingsLength
        };

        var chatStats = new IaChatStatisticsDto
        {
            AverageMessagesPerChat = chats.Count != 0 ? Math.Round(chats.Average(c => c.Messages.Count), 2) : 0,
            TotalChats = chats.Count
        };

        return GetOfficeAnalyticsResponse.FromOffice(
            office,
            totalProfessionals,
            totalServices,
            faqStats,
            totalHealthCares,
            chatRatingStats,
            chatStats
        );
    }
} 