using Application.DTOs.Patients.CreatePatientLeadDTOs;

namespace Application.Services.Patients;

public interface IPatientLeadService
{
    Task<CreatePatientLeadResponseDto> CreatePatientLeadAsync(CreatePatientLeadRequestDto requestDto);
} 