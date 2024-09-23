using Adapters.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Routers;

[ApiController]
[Route("api/patients")]
public class PatientRouter(IPatientController controller) : BaseRouter
{
    [HttpPost]
    [AllowAnonymous]
    [SwaggerResponse(StatusCodes.Status201Created, typeof(CreatePatientResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePatient(CreatePatientRequest request)
    {
        var result = await controller.CreatePatient(request);
        return HttpResponse(result);
    }
}