using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PointOfSale.Models;

namespace PointOfSale.Utils;

public static class Security
{
  public static string EncodeBcrypt(string data)
  {
    return BCrypt.Net.BCrypt.HashPassword(data);
  }
  public static bool VerifyBcrypt(string data, string hash)
  {
    return BCrypt.Net.BCrypt.Verify(data, hash);
  }
  public static string GenerateJwtToken(User user)
  {
    var claims = new[]
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
      new Claim(ClaimTypes.Name, user.Name!),
      new Claim(ClaimTypes.Email, user.Email!),
      new Claim(ClaimTypes.Role, user.Role!)
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY")!));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken
    (
      Environment.GetEnvironmentVariable("JWT_ISSUER"),
      Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
      claims,
      expires: DateTime.Now.AddHours(6),
      signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }
}