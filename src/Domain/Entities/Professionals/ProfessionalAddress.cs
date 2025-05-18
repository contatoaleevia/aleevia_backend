using CrossCutting.Entities;
using Domain.Entities.Addresses;

namespace Domain.Entities.Professionals;

public class ProfessionalAddress : Entity
{
    public Professional Professional { get; private set; } = null!;
    public Guid ProfessionalId { get; private set; }
    public Address Address { get; private set; } = null!;
    public Guid AddressId { get; private set; }

    public ProfessionalAddress(Guid professionalId, Guid addressId)
    {
        ProfessionalId = professionalId;
        AddressId = addressId;
    }

    public void Update(Guid addressId)
    {
        AddressId = addressId;
    }
}