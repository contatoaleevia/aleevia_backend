using Domain.Entities.Identities;

namespace Application.Helpers;

public interface IGenerateJwtTokenHelper
{
    string GenerateJwtToken(User user);
}