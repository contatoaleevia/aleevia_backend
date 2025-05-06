using Application.DTOs.Patients.CreatePatientDTOs;
using Domain.Entities.Patients;
using Domain.Contracts.Repositories;
using Domain.Exceptions;
namespace Application.Services.Patients;

public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    public async Task CreatePatient(CreatePatientUserRequest request, Guid userId)
    {
        try
        {
            var patient = new Patient(
                userId: userId,
                bloodType: request.BloodType,
                biologicalSex: request.BiologicalSex,
                pictureUrl: request.PictureUrl,
                gender: request.Gender,
                birthDate: request.BirthDate,
                preRegister: request.PreRegister
            );
            
            await patientRepository.CreateAsync(patient);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new CreatePatientException(userId);
        }
    }
} 