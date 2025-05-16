using Domain.Entities.IaChats;

namespace Application.DTOs.IaChats.CreateIaChatRatingDTOs;

public class CreateIaChatRatingResponseDto
{
    public Guid Id { get; set; }
    public Guid ChatId { get; set; }
    public int GeneralRating { get; set; }
    public required ExperienceType Experience { get; set; }
    public int Utility { get; set; }
    public required ProblemSolvedType ProblemSolved { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
} 