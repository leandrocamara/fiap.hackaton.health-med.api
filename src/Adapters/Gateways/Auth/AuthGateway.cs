using Adapters.Gateways.Doctors;
using Adapters.Gateways.Patients;
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

            if(user?.Doctor != null)
                roles.Add(Role.Doctor);

            if (user?.Patient != null)
                roles.Add(Role.Patient);
            
            var credentials = new Credentials(user.Id, roles);
            return Task.FromResult<Credentials>(credentials);
        }

        return Task.FromResult<Credentials>(null!);
    }

    public Task<string> GenerateToken(Credentials credentials) =>
        authClient.GenerateToken(credentials.UserId.ToString(), credentials.Roles);
}