using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace BlazorChatWebApp
{
  public class TokenService
  {
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    
    public static TokenValidationParameters GetTokenValidationParameters(IConfiguration configuration)
    {
      return new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        //ValidAudience = configuration["Jwt:Audience"],
        //IssuerSigningKey = 
      };
    }

    //public string GenerateJwt(IEnumerable<Claim> addClaim = null)
    //{
    //  var securityKey = GetSecurityKey();
    //}

  }
}
