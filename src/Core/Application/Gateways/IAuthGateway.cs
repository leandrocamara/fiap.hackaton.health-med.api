using Application.UseCases.Auth;

namespace Application.Gateways;

public interface IAuthGateway
{
    Task<Credentials> GetCredentials(string email, string password);
    Task<string> GenerateToken(Credentials credentials);
}