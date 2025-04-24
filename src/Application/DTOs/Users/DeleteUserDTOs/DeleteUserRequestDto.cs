namespace Application.DTOs.Users.DeleteUserDTOs;
public class DeleteUserRequestDto(Guid guid)
{
    public Guid Guid { get; set; } = guid;
}