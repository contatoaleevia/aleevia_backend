using System.Text.Json.Serialization;
using CrossCutting.Extensions;
using Domain.Entities.Identities.Enums;

namespace Domain.Entities.Identities;

public class ManagerType
{
    public ManagerTypeEnum TypeId { get; private set; }
    public string TypeName => TypeId.TryGetDescription();
    
    private ManagerType()
    {
    }

    [JsonConstructor]
    private ManagerType(ManagerTypeEnum typeId)
    {
        TypeId = typeId;
    }

    public ManagerType(ushort typeId)
    {
        TypeId = (ManagerTypeEnum) typeId;
    }
    
    public static ManagerType CreateAsIndividual()
        => new(ManagerTypeEnum.Individual);
}
