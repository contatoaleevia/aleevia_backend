using Microsoft.AspNetCore.Identity;

namespace CrossCutting.Session;

public interface IUserSession
{
    Guid UserId { get; }
    ushort? UserType { get; }
    string Email { get; }
    IEnumerable<IdentityRole<Guid>> Roles { get; }
    bool IsAuthenticated();
}
