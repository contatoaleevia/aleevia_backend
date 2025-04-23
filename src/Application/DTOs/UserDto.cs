using Domain.Entities.Identities;

namespace Application.DTOs
{
    public class UserDto
    {
        public UserDto(string firstName, string lastName, string preferredName, string gender, string document, string phoneNumber, string email, UserTypeEnum userType, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            PreferredName = preferredName;
            Gender = gender;
            Document = document;
            PhoneNumber = phoneNumber;
            Email = email;
            UserType = userType;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DeletedAt = deletedAt;
            Active = active;
        }

        public Guid Guid { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PreferredName { get; set; }
        public string Gender { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public UserTypeEnum UserType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Active { get; set; }
    }
}