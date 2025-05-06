using CrossCutting.Entities;
using Domain.Entities.Addresses;

namespace Domain.Entities.Offices;

public class OfficeAddress : Entity
{
    public Guid AddressId { get; set; }
    public Guid OfficeId { get; set; }
    public bool IsActive { get; set; }

    public Address Address { get; set; } = null!;
    public Office Office { get; set; } = null!;
    
    private OfficeAddress() { }
    
    public OfficeAddress(Guid addressId, Guid officeId)
    {
        AddressId = addressId;
        OfficeId = officeId;
        IsActive = true;
    }
}