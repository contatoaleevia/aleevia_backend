using CrossCutting.Notifications;
using Microsoft.AspNetCore.Identity;

namespace CrossCutting.Identities;

public class IdentityNotificationHandler(INotificationContext notificationContext) : IIdentityNotificationHandler
{
    public void AddNotifications(IEnumerable<IdentityError> identityErrors)
    {
        notificationContext.AddNotifications(identityErrors.ToList());
    }
}