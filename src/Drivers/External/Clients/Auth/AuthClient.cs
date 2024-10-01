using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Adapters.Gateways.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace External.Clients.Auth;

public class AuthClient(IOptions<AuthSettings> authSettings) : IAuthClient
{
    public Task<string> GenerateToken(string userId, List<string> roles)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Value.SecretKey));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.NameIdentifier, userId));
        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));


        var token = new JwtSecurityToken(
            issuer: authSettings.Value.Issuer,
            audience: authSettings.Value.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: signingCredentials
        );

        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
    }
}