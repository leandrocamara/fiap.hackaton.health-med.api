using Application.Gateways;
using Application.UseCases.Auth;
using Entities.SeedWork.Extensions;

namespace Adapters.Gateways.Auth;

public class AuthGateway(
    IAuthClient authClient, IUserRepository userRepository) : IAuthGateway
{
    public Task<Credentials> GetCredentials(string email, string password)
    {
        var user = userRepository.GetByEmail(email);

        // if (user?.Password == password.ToMd5())
        // {
        //     var credentials = new Credentials(user.Id, nameof(user.Type));
        //     return Task.FromResult<Credentials>(credentials);
        // }
            
        return Task.FromResult<Credentials>(null!);
    }

    public Task<string> GenerateToken(Credentials credentials) =>
        authClient.GenerateToken(credentials.UserId.ToString(), credentials.Role);
}