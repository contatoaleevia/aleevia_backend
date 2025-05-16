using System.Text.Json.Serialization;
using CrossCutting.Extensions;
using Domain.Entities.IaChats.Enums;

namespace Domain.Entities.IaChats;

public class ExperienceType
{
    [JsonPropertyName("experienceTypeId")]
    public ExperienceTypeEnum ExperienceTypeId { get; set; }
    public string ExperienceTypeName => ExperienceTypeId.TryGetDescription();
    
    private ExperienceType()
    {
    }

    [JsonConstructor]
    public ExperienceType(ExperienceTypeEnum experienceTypeId)
    {
        ExperienceTypeId = experienceTypeId;
    }
    
    public static ExperienceType CreateAsVeryGood() => new(ExperienceTypeEnum.VeryGood);
    public static ExperienceType CreateAsGood() => new(ExperienceTypeEnum.Good);
    public static ExperienceType CreateAsRegular() => new(ExperienceTypeEnum.Regular);
    public static ExperienceType CreateAsBad() => new(ExperienceTypeEnum.Bad);
    public static ExperienceType CreateAsVeryBad() => new(ExperienceTypeEnum.VeryBad);
} 