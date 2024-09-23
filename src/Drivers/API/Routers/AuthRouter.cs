using Adapters.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Routers;

[ApiController]
[Route("api/auth")]
public class AuthRouter(IAuthController controller) : BaseRouter
{
    [HttpPost]
    [AllowAnonymous]
    [SwaggerResponse(StatusCodes.Status200OK, typeof(TokenResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SignIn(CredentialsRequest request)
    {
        var result = await controller.SignIn(request);
        return HttpResponse(result);
    }
}