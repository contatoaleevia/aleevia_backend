namespace Application.DTOs.Users.CreateAdminUserDTOs;

public class CreateManagerUserResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public CreateManagerUserResponse()
    {
    }
    
    public CreateManagerUserResponse(Guid id, string userName, string email)
    {
        Id = id;
        UserName = userName;
        Email = email;
    }
}