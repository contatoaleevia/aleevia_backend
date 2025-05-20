namespace Application.DTOs.IaChats;

public class IaChatRatingStatisticsDto
{
    public double AverageGeneralRating { get; set; }
    public double AverageExperience { get; set; }
    public double AverageUtility { get; set; }
    public double AverageProblemSolved { get; set; }
    public int TotalRatings { get; set; }
} 