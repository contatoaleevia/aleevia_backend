using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities.Identities;
using Infrastructure.Helpers.ApiSettings.Settings;
using Infrastructure.Helpers.TokenObtainer.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Helpers;

public class GenerateJwtTokenHelper(IConfiguration configuration) : IGenerateJwtTokenHelper
{
    public string GenerateJwtToken(User user, Guid? managerId, bool rememberMe)
    {
        var settings = TokenObtainHelperSettings.GetInstance(configuration);
        var apiSettings = ApiSettingsHelper.GetInstance(configuration);
        
        List<Claim> claims =
        [
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email!),
            new(ClaimTypes.Actor, user.GetUserTypeId().ToString()),
            new("ManagerId", managerId.ToString() ?? string.Empty)
        ];
        
        claims.AddRange(user.GetRolesNames().Select(role => new Claim(ClaimTypes.Role, role)));
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: credentials,
            expires: rememberMe 
                        ? DateTime.UtcNow.AddHours(apiSettings.ExpireHourWithRememberMe) 
                        : DateTime.UtcNow.AddHours(apiSettings.ExpireHourWithoutRememberMe),
            issuer: apiSettings.Issuer,
            audience: apiSettings.ValidIn
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        
        if (string.IsNullOrEmpty(tokenString)) 
            throw new InvalidOperationException("Ocorreu um erro na geração do token");

        return tokenString;
    }
}