using CrossCutting.Entities;

namespace Domain.Doctors.Entities;

public class Doctor(string name) : AggregateRoot<Guid>
{
    public string Name { get; set; } = name;
}