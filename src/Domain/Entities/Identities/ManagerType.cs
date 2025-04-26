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

    public ManagerType(ushort typeId)
    {
        TypeId = (ManagerTypeEnum) typeId;
    }
}
