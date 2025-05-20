using CrossCutting.Entities;
using Domain.Entities.IaChats.Enums;

namespace Domain.Entities.IaChats;

public class IaChatRating : AggregateRoot
{
    public Guid ChatId { get; private set; }
    public int GeneralRating { get; private set; }
    public ExperienceTypeEnum ExperienceType { get; private set; }
    public int Utility { get; private set; }
    public ProblemSolvedTypeEnum ProblemSolvedType { get; private set; }
    public string? Comment { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IaChat Chat { get; private set; } = null!;

    private IaChatRating() { }

    public IaChatRating(
        Guid chatId,
        int generalRating,
        ExperienceTypeEnum experienceType,
        int utility,
        ProblemSolvedTypeEnum problemSolvedType,
        string? comment)
    {
        ChatId = chatId;
        GeneralRating = generalRating;
        ExperienceType = experienceType;
        Utility = utility;
        ProblemSolvedType = problemSolvedType;
        Comment = comment;
        CreatedAt = DateTime.UtcNow;
    }

    public ExperienceType GetExperience() => new(ExperienceType);

    public ProblemSolvedType GetProblemSolved() => new(ProblemSolvedType);
} 