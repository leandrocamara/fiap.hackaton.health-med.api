using Adapters.Controllers;
using Application.UseCases.Appointments;
using Application.UseCases.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Routers;

[ApiController]
[Route("api/appointments")]
public class AppointmentRouter(IAppointmentController controller) : BaseRouter
{
    [HttpPost]
    [Authorize(Roles = Role.Patient)]
    [SwaggerResponse(StatusCodes.Status201Created, "", typeof(ScheduleAppointmentResponse))]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status403Forbidden)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ScheduleAppointment(ScheduleAppointmentRequest request)
    {
        request.SetPatientId(GetAuthenticatedUserId());
        var result = await controller.ScheduleAppointment(request);
        return HttpResponse(result);
    }

    [HttpGet]
    [Authorize(Roles = Role.Doctor)]
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(GetScheduledAppointmentsResponse))]
    [SwaggerResponse(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(StatusCodes.Status403Forbidden)]
    [SwaggerResponse(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetScheduledAppointments()
    {
        var doctorId = GetAuthenticatedUserId();
        var result = await controller.GetScheduledAppointments(doctorId);
        return HttpResponse(result);
    }
}