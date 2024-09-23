using Adapters.Controllers.Common;
using Application.UseCases.Auth;

namespace Adapters.Controllers;

public interface IAuthController
{
    Task<Result> SignIn(SignInRequest request);
}

public sealed class AuthController(
    ISignInUseCase signInUseCase) : BaseController, IAuthController
{
    public async Task<Result> SignIn(SignInRequest request)
    {
        try
        {
            var response = await Execute(() => signInUseCase.Execute(request));
            return Result.Success(response);
        }
        catch (ControllerException e)
        {
            return e.Result;
        }
    }
}