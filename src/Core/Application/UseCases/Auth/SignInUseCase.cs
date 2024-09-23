namespace Application.UseCases.Auth;

public interface ISignInUseCase : IUseCase<SignInRequest, SignInResponse>;

public sealed class SignInUseCase : ISignInUseCase
{
    public Task<SignInResponse> Execute(SignInRequest request)
    {
        throw new NotImplementedException();
    }
}

public record SignInRequest;

public record SignInResponse;