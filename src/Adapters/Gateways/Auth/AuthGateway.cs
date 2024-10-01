using Application.Gateways;
using Application.UseCases.Auth;
using Entities.SeedWork.Extensions;

namespace Adapters.Gateways.Auth;

public class AuthGateway(
    IAuthClient authClient,
    IUserRepository userRepository) : IAuthGateway
{
    public Task<Credentials> GetCredentials(string email, string password)
    {
        var user = userRepository.GetByEmail(email);

        List<string> roles = new();

        if (string.Equals(user?.Password, password.ToMd5(), StringComparison.OrdinalIgnoreCase))
        {
            Credentials credentials = null!;

            if (user?.Doctor != null)
                credentials = new Credentials(user.Doctor.Id, [Role.Doctor]);
            else if (user?.Patient != null)
                credentials = new Credentials(user.Patient.Id, [Role.Patient]);

            return Task.FromResult(credentials!);
        }

        return Task.FromResult<Credentials>(null!);
    }

    public Task<string> GenerateToken(Credentials credentials) =>
        authClient.GenerateToken(credentials.UserId.ToString(), credentials.Roles);
}