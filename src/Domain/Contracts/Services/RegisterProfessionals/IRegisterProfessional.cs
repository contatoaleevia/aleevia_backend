using Domain.Entities.Professionals;

namespace Domain.Contracts.Services.RegisterProfessionals;

public interface IRegisterProfessional
{
    void Register(Professional professional, RegisterProfessionalRequest request);
}