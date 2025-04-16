namespace Application.Doctors.DTOs.CreateDoctor;

public class CreateDoctorRequest(string name)
{
    public string Name { get; set; } = name;
}