using CrossCutting.Entities;

namespace Domain.Entities.Identities;

public class Manager : AggregateRoot
{
    public Guid UserId { get; private set; }
    public ManagerType ManagerType { get; private set; }
    public string? CorporateName { get; private set; }
    
    public User User { get; set; }

    private Manager()
    {
    }
    
    public Manager(Guid userId, ManagerType managerType, string? corporateName)
    {
        UserId = userId;
        ManagerType = managerType;
        CorporateName = corporateName;
    }
}