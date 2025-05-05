using Application.DTOs.Patients.CreatePatientDTOs;
using Domain.Entities.Identities;
using Domain.Entities.Patients;
using Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Identity;
using Domain.Exceptions;

namespace Application.Services.Patients;

public class PatientService(
    IPatientRepository patientRepository,
    UserManager<User> userManager
) : IPatientService
{
    public async Task<CreatePatientResponseDto> CreatePatientAsync(CreatePatientRequestDto requestDto)
    {
        var user = new User(
            email: requestDto.Email,
            phoneNumber: requestDto.PhoneNumber,
            name: requestDto.Name,
            cpf: requestDto.Cpf,
            cnpj: requestDto.Cnpj,
            userType: UserType.Patient
        );

        var result = await userManager.CreateAsync(user, requestDto.Password);

        if (!result.Succeeded) throw new CreateUserException(user.Id);

        var patient = new Patient(
            userId: user.Id,
            bloodType: requestDto.BloodType,
            biologicalSex: requestDto.BiologicalSex,
            pictureUrl: requestDto.PictureUrl,
            gender: requestDto.Gender,
            birthDate: requestDto.BirthDate,
            preRegister: requestDto.PreRegister,
            googleToken: requestDto.GoogleToken,
            googleRefreshToken: requestDto.GoogleRefreshToken
        );
        
        await patientRepository.CreateAsync(patient);

        return new CreatePatientResponseDto
        {
            Id = patient.Id,
            UserId = patient.UserId,
            Name = user.Name,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Cpf = user.Cpf.Value,
            Cnpj = user.Cnpj?.Value,
            BirthDate = patient.BirthDate,
            BloodType = patient.GetBloodTypeDescription(),
            BiologicalSex = patient.GetBiologicalSexDescription(),
            PictureUrl = patient.PictureUrl,
            Gender = patient.GetGenderDescription(),
            PreRegister = patient.PreRegister,
            CreatedAt = patient.CreatedAt
        };
    }
} 