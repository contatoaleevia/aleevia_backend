using Microsoft.AspNetCore.Identity;

namespace CrossCutting.Notifications;

public interface INotificationContext
{
    IList<Notification> Notifications { get; }
    bool HasNotifications { get; }
    void AddNotifications(IList<IdentityError> identityErrors);
}