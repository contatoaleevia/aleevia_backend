using System.Security.Claims;
using CrossCutting.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CrossCutting.Session;

public class UserSession : IUserSession
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ClaimRetriever _claimRetriever;

    public UserSession(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
        _claimRetriever = new ClaimRetriever(GetClaims());
    }

    public Guid UserId => IsAuthenticated() ? _claimRetriever.GetUserId() : Guid.Empty;
    public string UserType => IsAuthenticated() ? _claimRetriever.GetUserType() : string.Empty;
    public string Email => IsAuthenticated() ? _claimRetriever.GetEmail() : string.Empty;
    public IEnumerable<IdentityRole<Guid>> Roles => IsAuthenticated() ? _claimRetriever.GetRoles() : [];

    public bool IsAuthenticated()
    {
        var httpContext = _contextAccessor.HttpContext;
        if (httpContext == null)
            return false;

        var identity = httpContext.User.Identity;
        return identity != null && identity.IsAuthenticated;
    }

    private IEnumerable<Claim> GetClaims()
    {
        var httpContext = _contextAccessor.HttpContext;
        return httpContext == null ? [] : httpContext.User.Claims;
    }

    private class ClaimRetriever(IEnumerable<Claim> claims)
    {
        public Guid GetUserId()
        {
            var userIdClaim = FindClaimValue(ClaimTypes.NameIdentifier);
            return Guid.TryParse(userIdClaim, out var userId) ? userId : Guid.Empty;
        }

        public string GetUserType()
            => FindClaimValue(ClaimTypes.Actor);

        public string GetEmail()
            => FindClaimValue(ClaimTypes.Email);

        public IEnumerable<IdentityRole<Guid>> GetRoles()
        {
            var rolesClaim = FindClaimValues(ClaimTypes.Role);
            if (rolesClaim.Count == 0)
                return [];

            return rolesClaim
                .Select(r => RoleUtils.GetRole(r.Value));
        }

        private string FindClaimValue(string claimType)
            => claims
                .FirstOrDefault(x => x.Type.Equals(claimType))?
                .Value ?? string.Empty;
        
        private List<Claim> FindClaimValues(string claimType)
            => claims
                .Where(x => x.Type.Equals(claimType))
                .ToList();
    }
}
