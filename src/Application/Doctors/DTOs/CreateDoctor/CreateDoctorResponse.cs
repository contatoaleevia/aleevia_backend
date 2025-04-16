using Domain.Doctors.Entities;

namespace Application.Doctors.DTOs.CreateDoctor;

public class CreateDoctorResponse(Doctor doctor)
{
    public Guid Id { get; set; } = doctor.Id;
    public string Name { get; set; } = doctor.Name;
}