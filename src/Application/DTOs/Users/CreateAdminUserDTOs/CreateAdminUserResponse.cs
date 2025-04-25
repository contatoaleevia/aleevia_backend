namespace Application.DTOs.Users.CreateAdminUserDTOs;

public class CreateAdminUserResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public CreateAdminUserResponse()
    {
    }
    
    public CreateAdminUserResponse(Guid id, string userName, string email)
    {
        Id = id;
        UserName = userName;
        Email = email;
    }
}