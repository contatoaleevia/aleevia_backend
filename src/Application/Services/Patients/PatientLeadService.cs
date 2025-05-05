using Application.DTOs.Patients.CreatePatientLeadDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Patients;
using Domain.Exceptions;
namespace Application.Services.Patients;

public class PatientLeadService(IPatientLeadRepository patientLeadRepository) : IPatientLeadService
{
    public async Task<CreatePatientLeadResponseDto> CreatePatientLeadAsync(CreatePatientLeadRequestDto requestDto)
    {
        var existingLead = await patientLeadRepository.GetByCpfOrEmailAsync(requestDto.Cpf, requestDto.Email);
        if (existingLead != null) throw new LeadAlreadyExistException();

        var patientLead = new PatientLead(
            name: requestDto.Name,
            phone: requestDto.Phone,
            cpf: requestDto.Cpf,
            birthDate: requestDto.BirthDate,
            email: requestDto.Email
        );
        
        await patientLeadRepository.CreateAsync(patientLead);

        return new CreatePatientLeadResponseDto
        {
            Id = patientLead.Id,
            Name = patientLead.Name,
            Phone = patientLead.Phone,
            Cpf = patientLead.Cpf.Value,
            BirthDate = patientLead.BirthDate,
            Email = patientLead.Email,
            CreatedAt = patientLead.CreatedAt
        };
    }
} 