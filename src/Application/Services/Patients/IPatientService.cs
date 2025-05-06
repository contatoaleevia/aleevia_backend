using Application.DTOs.Patients.CreatePatientDTOs;

namespace Application.Services.Patients;

public interface IPatientService
{
    Task CreatePatient(CreatePatientUserRequest request, Guid userId);
} 