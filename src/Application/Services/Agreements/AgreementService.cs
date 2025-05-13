using Application.DTOs.Agreements.CreateAgreementDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Agreements;

namespace Application.Services.Agreements;
public class AgreementService(IAgreementRepository agreementRepository) : IAgreementService
{
    public async Task<CreateAgreementResponse> CreateAgreementAsync(CreateAgreementRequest requestDto)
    {
        var newAgreement = new Agreement(
            officeId: requestDto.OfficeId,
            name: requestDto.Name,
            ansNumber: requestDto.AnsNumber,
            registration: requestDto.Registration,
            active: requestDto.Active
            );

        var agreement = await agreementRepository.CreateAsync(newAgreement);

        return new CreateAgreementResponse() { Id = agreement.Id };
    }
}