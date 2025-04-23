using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Entities;

public abstract class Entity
{
    [Key]
    public Guid Id { get; protected set; } = Guid.NewGuid();
}