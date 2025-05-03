using System.Text.Json.Serialization;
using CrossCutting.Extensions;

namespace Application.DTOs.Users.LoginDTOs;

public record LoginRequestDto(string UserName, string Password, bool RememberMe)
{
    public string UserName { get; set; } = UserName;

    public string Password { get; set; } = Password;
    public bool RememberMe { get; set; } = RememberMe;

    [JsonIgnore]
    public string Document => UserName.RemoveSpecialCharacters();
}