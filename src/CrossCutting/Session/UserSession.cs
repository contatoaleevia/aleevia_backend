using System.Security.Claims;
using Microsoft.AspNetCore.Http;

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
    public ushort? UserType => IsAuthenticated() ? _claimRetriever.GetUserType() : null;
    public string Email => IsAuthenticated() ? _claimRetriever.GetEmail() : string.Empty;
    public IEnumerable<string> Roles => IsAuthenticated() ? _claimRetriever.GetRoles() : [];
    public Guid? ManagerId => IsAuthenticated() ? _claimRetriever.GetManagerId() : null;

    public bool IsAuthenticated()
    {
        var httpContext = _contextAccessor.HttpContext;
        var identity = httpContext?.User.Identity;
        return identity is { IsAuthenticated: true };
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

        public ushort? GetUserType()
            => ushort.TryParse(FindClaimValue(ClaimTypes.Actor), out var userType) ? userType : null;

        public string GetEmail()
            => FindClaimValue(ClaimTypes.Email);

        public IEnumerable<string> GetRoles()
        {
            var rolesClaim = FindClaimValues(ClaimTypes.Role);
            if (rolesClaim.Count == 0)
                return [];

            return rolesClaim
                .Select(r => r.Value);
        }

        public Guid? GetManagerId()
            => Guid.Parse(FindClaimValue("ManagerId"));

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
