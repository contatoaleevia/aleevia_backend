using System.Text.Json.Serialization;
using CrossCutting.Extensions;

namespace Application.DTOs.Users.LoginDTOs;

public record LoginRequestDto(string UserName, string Password, bool RememberMe)
{
    [JsonIgnore]
    public string Document => UserName.RemoveSpecialCharacters();
}