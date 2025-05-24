namespace CrossCutting.Session;

public interface IUserSession
{
    Guid UserId { get; }
    ushort? UserType { get; }
    Guid? ManagerId { get; }
}
