using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BancoApi.Entities;
using Microsoft.IdentityModel.Tokens;

namespace BancoApi.Services;

public class TokenService(IConfiguration config)
{
    public string GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(config["Jwt:Key"]!)
        );
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Claims — dados que ficam NO token
        var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())   // ex: "Admin"
        };

        var token = new JwtSecurityToken(
            issuer:    config["Jwt:Issuer"],
            audience:  config["Jwt:Audience"],
            claims:    claims,
            expires:   DateTime.UtcNow.AddMinutes(60),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}