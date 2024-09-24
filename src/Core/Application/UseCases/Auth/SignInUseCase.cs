using Application.Gateways;

namespace Application.UseCases.Auth;

public interface ISignInUseCase : IUseCase<SignInRequest, SignInResponse>;

public sealed class SignInUseCase(
    IAuthGateway authGateway) : ISignInUseCase
{
    public async Task<SignInResponse> Execute(SignInRequest request)
    {
        try
        {
            var credentials = await authGateway.GetCredentials(request.Cpf, request.Password);

            if (credentials is null)
                throw new ApplicationException("Invalid username or password.");

            var token = await authGateway.GenerateToken(credentials);

            return new SignInResponse(token);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Failed to get token. Error: {e.Message}", e);
        }
    }
}

public record SignInRequest(string Cpf, string Password);

public record SignInResponse(string Token);