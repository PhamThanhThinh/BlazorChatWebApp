using BlazorChatWebApp.Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorChatWebApp
{
  public class TokenService
  {
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    
    public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration) =>
    
      new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        IssuerSigningKey = GetSecurityKey(configuration)
        //ValidAudience = _configuration["Jwt:Audience"],
      };


    public string GenerateJWT(IEnumerable<Claim> addClaim = null)
    {
      var securityKey = GetSecurityKey(_configuration);
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
      //var expires = DateTime.Now.AddMinutes(30);
      var expiresInMinutes = Convert.ToInt32(_configuration["Jwt:ExpireInMinutes"] ?? "60");

      var claims = new List<Claim>
      {
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };

      //if (addClaim != null)
      //{
      //  claims.AddRange(addClaim);
      //}

      if (addClaim?.Any() == true)
      {
        claims.AddRange(addClaim);
      }

      var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: "*",
        claims: claims,
        expires: DateTime.Now.AddMinutes(expiresInMinutes),
        signingCredentials: credentials
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateJWT(User user, IEnumerable<Claim>? addClaim = null)
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
      };
      if (addClaim?.Any() == true)
      {
        claims.AddRange(addClaim);
      }
      return GenerateJWT(claims);
    }

    private static SymmetricSecurityKey GetSecurityKey(IConfiguration _configuration) =>
            new(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
  }
}
