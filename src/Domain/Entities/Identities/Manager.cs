using CrossCutting.Entities;

namespace Domain.Entities.Identities;

public class Manager : AggregateRoot
{
    public Guid UserId { get; private set; }
    public ManagerType ManagerType { get; private set; } = null!;
    public string? CorporateName { get; private set; }
    
    public User User { get; set; } = null!;

    private Manager()
    {
    }
    
    public Manager(Guid userId, ManagerType managerType, string? corporateName)
    {
        UserId = userId;
        ManagerType = managerType;
        CorporateName = corporateName;
    }
    
    public void Update(string? corporateName)
    {
        CorporateName = corporateName;
    }
    
    public ushort? GetTypeId() => (ushort) ManagerType.TypeId;
}