using Application.DTOs.Patients.CreatePatientDTOs;

namespace Application.Services.Patients;

public interface IPatientService
{
    Task<CreatePatientResponseDto> CreatePatientAsync(CreatePatientRequestDto requestDto);
} 