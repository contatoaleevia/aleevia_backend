using CrossCutting.Extensions;
using Domain.Entities.Patients.Enums;

namespace Domain.Entities.Patients;

public class BiologicalSex
{
    public BiologicalSexEnum TypeId { get; private set; }
    public string TypeName => TypeId.TryGetDescription();
    
    private BiologicalSex()
    {
    }

    public BiologicalSex(ushort typeId)
    {
        TypeId = (BiologicalSexEnum)typeId;
    }
    
    private BiologicalSex(BiologicalSexEnum typeId)
    {
        TypeId = typeId;
    }
    
    public static BiologicalSex Male => new(BiologicalSexEnum.Male);
    public static BiologicalSex Female => new(BiologicalSexEnum.Female);
    public static BiologicalSex Other => new(BiologicalSexEnum.Other);

} 