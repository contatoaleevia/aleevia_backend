namespace Application.DTOs.Users.DeleteUserDTOs;
public class DeleteUserResponseDto(Guid guid)
{
    public Guid Guid { get; set; } = guid;
}