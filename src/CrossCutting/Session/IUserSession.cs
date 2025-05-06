namespace CrossCutting.Session;

public interface IUserSession
{
    Guid UserId { get; }
    ushort? UserType { get; }
    string Email { get; }
    IEnumerable<string> Roles { get; }
    bool IsAuthenticated();
    Guid? ManagerId { get; }
}
