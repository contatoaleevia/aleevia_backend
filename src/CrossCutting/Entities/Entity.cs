using System.ComponentModel.DataAnnotations;

namespace CrossCutting.Entities;

public abstract class Entity<TKey> where TKey : notnull
{
    [Key]
    public TKey Id { get; protected set; } = default!;
}