namespace Application.DTOs.Users.CreateHealthcareUserDTOs;

public class CreateHealthcareUserResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;

    public CreateHealthcareUserResponse()
    {
    }
    
    public CreateHealthcareUserResponse(Guid id, string userName, string email)
    {
        Id = id;
        UserName = userName;
        Email = email;
    }
}