using Application.Doctors.DTOs.CreateDoctor;
using Domain.Doctors.Entities;

namespace Application.Doctors.Contracts;

public interface IDoctorService
{
    public Task<CreateDoctorResponse> CreateDoctorAsync(CreateDoctorRequest doctor);
}