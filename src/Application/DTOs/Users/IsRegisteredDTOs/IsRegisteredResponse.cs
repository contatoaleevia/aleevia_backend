namespace Application.DTOs.Users.IsRegisteredDTOs;

public record IsRegisteredResponse(bool IsRegistered, Guid? UserId = null)
{
    public bool IsRegistered { get; set; } = IsRegistered;
    public Guid? UserId { get; set; } = UserId;
}