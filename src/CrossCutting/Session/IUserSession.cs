namespace CrossCutting.Session;

public interface IUserSession
{
    Guid UserId { get; }
    string UserType { get; }
    string Email { get; }
    IEnumerable<string> Roles { get; }
    bool IsAuthenticated();
}
