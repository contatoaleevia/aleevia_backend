using System;

namespace Domain.Exceptions.Professionals;

public class SubSpecialityNotFoundException(Guid id) : Exception($"Sub-especialidade com ID {id} não encontrada.")
{
} 