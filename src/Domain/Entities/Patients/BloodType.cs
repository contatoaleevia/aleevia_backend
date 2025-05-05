using CrossCutting.Extensions;
using Domain.Entities.Patients.Enums;

namespace Domain.Entities.Patients;

public class BloodType
{
    public BloodTypeEnum TypeId { get; private set; }
    public string TypeName => TypeId.TryGetDescription();
    
    private BloodType()
    {
    }

    public BloodType(ushort typeId)
    {
        TypeId = (BloodTypeEnum)typeId;
    }
    
    private BloodType(BloodTypeEnum typeId)
    {
        TypeId = typeId;
    }
    
    public static BloodType APositive => new(BloodTypeEnum.APositive);
    public static BloodType ANegative => new(BloodTypeEnum.ANegative);
    public static BloodType BPositive => new(BloodTypeEnum.BPositive);
    public static BloodType BNegative => new(BloodTypeEnum.BNegative);
    public static BloodType ABPositive => new(BloodTypeEnum.ABPositive);
    public static BloodType ABNegative => new(BloodTypeEnum.ABNegative);
    public static BloodType OPositive => new(BloodTypeEnum.OPositive);
    public static BloodType ONegative => new(BloodTypeEnum.ONegative);
    public static BloodType Unknown => new(BloodTypeEnum.Unknown);
}