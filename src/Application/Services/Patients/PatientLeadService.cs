using Application.DTOs.Patients.CreatePatientLeadDTOs;
using Domain.Contracts.Repositories;
using Domain.Entities.Patients;
using Domain.Exceptions;
namespace Application.Services.Patients;

public class PatientLeadService(IPatientLeadRepository patientLeadRepository) : IPatientLeadService
{
    public async Task<CreatePatientLeadResponse> CreatePatientLeadAsync(CreatePatientLeadRequest request)
    {
        var existingLead = await patientLeadRepository.GetByCpfOrEmailAsync(request.Cpf, request.Email);
        if (existingLead != null) throw new LeadAlreadyExistException();

        var patientLead = new PatientLead(
            name: request.Name,
            phone: request.Phone,
            cpf: request.Cpf,
            birthDate: request.BirthDate,
            email: request.Email
        );
        
        await patientLeadRepository.CreateAsync(patientLead);

        return new CreatePatientLeadResponse
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