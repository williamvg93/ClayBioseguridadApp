using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClayBio.Dtos.Post.Authentication;

public class UserDataDto
{
    public string Message { get; set; }
    public bool IsAuthenticated { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }
    public string Token { get; set; }

    [JsonIgnore] // ->this attribute restricts the property to be shown in the result
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiration { get; set; }
}
