namespace CrossCutting.Notifications;

public class Notification(string message, string type)
{
    public string Message { get; } = message;
    public string Type { get; } = type;
}