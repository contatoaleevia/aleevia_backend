using Microsoft.AspNetCore.Identity;

namespace CrossCutting.Notifications;

public class NotificationContext : INotificationContext
{
    public IList<Notification> Notifications => _notifications;
    public bool HasNotifications => _notifications.Count != 0;

    private readonly List<Notification> _notifications = [];

    public void AddNotifications(IList<IdentityError> identityErrors)
    {
        var notifications = identityErrors.Select(x =>
            new Notification(x.Description, x.GetType().Name));
        _notifications.AddRange(notifications);
    }
}