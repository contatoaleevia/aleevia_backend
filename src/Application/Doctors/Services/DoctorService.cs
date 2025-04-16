using Application.Doctors.Contracts;
using Application.Doctors.DTOs.CreateDoctor;
using Domain.Doctors.Contracts;
using Domain.Doctors.Entities;

namespace Application.Doctors.Services;

public class DoctorService(IDoctorRepository repository) : IDoctorService
{
    public async Task<CreateDoctorResponse> CreateDoctorAsync(CreateDoctorRequest request)
    {
        var doctor = new Doctor(request.Name);
        var createdDoctor = await repository.CreateAsync(doctor);
        return new CreateDoctorResponse(createdDoctor);
    }
}