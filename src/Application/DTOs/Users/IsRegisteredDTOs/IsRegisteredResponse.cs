using JetBrains.Annotations;

namespace Application.DTOs.Users.IsRegisteredDTOs;

public record IsRegisteredResponse(bool IsRegistered, Guid? UserId = null)
{
    [UsedImplicitly] public bool IsRegistered { get; } = IsRegistered;
    public Guid? UserId { get; set; } = UserId;
}