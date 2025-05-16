using System.Text.Json.Serialization;
using CrossCutting.Extensions;
using Domain.Entities.IaChats.Enums;

namespace Domain.Entities.IaChats;

public class ProblemSolvedType
{
    [JsonPropertyName("problemSolvedTypeId")]
    public ProblemSolvedTypeEnum ProblemSolvedTypeId { get; set; }
    public string ProblemSolvedTypeName => ProblemSolvedTypeId.TryGetDescription();
    
    private ProblemSolvedType()
    {
    }

    [JsonConstructor]
    public ProblemSolvedType(ProblemSolvedTypeEnum problemSolvedTypeId)
    {
        ProblemSolvedTypeId = problemSolvedTypeId;
    }
    
    public static ProblemSolvedType CreateAsYes() => new(ProblemSolvedTypeEnum.Yes);
    public static ProblemSolvedType CreateAsPartially() => new(ProblemSolvedTypeEnum.Partially);
    public static ProblemSolvedType CreateAsNo() => new(ProblemSolvedTypeEnum.No);
} 