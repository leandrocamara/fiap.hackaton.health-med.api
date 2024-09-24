using Application.UseCases.Auth;

namespace Application.Gateways;

public interface IAuthGateway
{
    Task<Credentials> GetCredentials(string cpf, string password);
    Task<string> GenerateToken(Credentials credentials);
}