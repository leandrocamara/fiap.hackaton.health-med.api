namespace Adapters.Gateways.Auth;

public interface IAuthClient
{
    Task<string> GenerateToken(string userId, List<string> roles);
}