using Application.Gateways;
using Application.UseCases.Auth;

namespace Adapters.Gateways.Auth;

public class AuthGateway(
    IAuthClient authClient) : IAuthGateway
{
    public Task<Credentials> GetCredentials(string cpf, string password)
    {
        // TODO: Use Repository
        return Task.FromResult<Credentials>(null!);
    }

    public Task<string> GenerateToken(Credentials credentials) =>
        authClient.GenerateToken(credentials.UserId.ToString(), credentials.Role);
}