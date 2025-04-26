using Microsoft.AspNetCore.Identity;

namespace CrossCutting.Identities;

public interface IIdentityNotificationHandler
{
    void AddNotifications(IEnumerable<IdentityError> identityErrors);
}