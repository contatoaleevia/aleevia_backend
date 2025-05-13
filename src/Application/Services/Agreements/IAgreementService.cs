using Application.DTOs.Agreements.CreateAgreementDTOs;

namespace Application.Services.Agreements;
public interface IAgreementService
{
    Task<CreateAgreementResponse> CreateAgreementAsync(CreateAgreementRequest requestDto);
}