using Adapters.Controllers;
using Application.UseCases.Auth;
using Application.UseCases.Doctors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Routers;

[ApiController]
[Route("api/doctors")]
public class DoctorRouter(IDoctorController controller) : BaseRouter
{
    [HttpPost]
    [AllowAnonymous]
    [SwaggerResponse(StatusCodes.Status201Created, "", typeof(CreateDoctorResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateDoctor(CreateDoctorRequest request)
    {
        var result = await controller.CreateDoctor(request);
        return HttpResponse(result);
    }

    [HttpGet]
    [AllowAnonymous]
    //[Authorize(Roles = Role.Patient)]
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(IEnumerable<GetDoctorResponse>))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status403Forbidden)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDoctors()
    {
        var result = await controller.GetDoctors();
        return HttpResponse(result);
    }

    [HttpPost("availability")]
    [Authorize(Roles = Role.Doctor)]
    [SwaggerResponse(StatusCodes.Status201Created, "", typeof(CreateAvailabilityResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status403Forbidden)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAvailability(CreateAvailabilityRequest request)
    {
        request.SetDoctorId(GetAuthenticatedUserId());
        var result = await controller.CreateAvailability(request);
        return HttpResponse(result);
    }

    [HttpGet("availability")]
    [Authorize(Roles = $"{Role.Patient},{Role.Doctor}")]
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(GetAvailabilityResponse))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status403Forbidden)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAvailability([FromQuery] Guid? doctorId)
    {
        doctorId ??= GetAuthenticatedUserId();
        var result = await controller.GetAvailability(doctorId.Value);
        return HttpResponse(result);
    }

    [HttpPut("availability")]
    [Authorize(Roles = Role.Doctor)]
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(UpdateAvailabilityResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status403Forbidden)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAvailability(UpdateAvailabilityRequest request)
    {
        request.SetDoctorId(GetAuthenticatedUserId());
        var result = await controller.UpdateAvailability(request);
        return HttpResponse(result);
    }
}