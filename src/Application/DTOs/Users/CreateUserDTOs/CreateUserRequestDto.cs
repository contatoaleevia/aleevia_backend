namespace Application.DTOs.Users.CreateUserDTOs;

public class CreateUserRequestDto(
    string password,
    string userName,
    string firstName,
    string lastName,
    string preferredName,
    string gender,
    string document,
    string phoneNumber,
    string email,
    ushort userType)
{
    public string Password { get; set; } = password;
    public string UserName { get; set; } = userName;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string PreferredName { get; set; } = preferredName;
    public string Gender { get; set; } = gender;
    public string Document { get; set; } = document;
    public string PhoneNumber { get; set; } = phoneNumber;
    public string Email { get; set; } = email;
    public ushort UserType { get; set; } = userType;
}