using Domain.Contracts.Services.RegisterProfessionals;
using Domain.Entities.Professionals;

namespace Domain.Services.Professionals;

public class RegisterProfessional : IRegisterProfessional
{
    public void Register(Professional professional, RegisterProfessionalRequest request)
    {
        professional.Register(
            name: request.Name,
            preferredName: request.PreferredName,
            email: request.Email,
            cnpj: request.Cnpj,
            webSite: request.Website,
            instagram: request.Instagram,
            biography: request.Biography);

        var manager = professional.Manager;
        manager.Update(request.CorporateName);
        
        var user = manager.User;
        user.UpdateFromRegister(request.Cnpj, request.Phone);
    }
}