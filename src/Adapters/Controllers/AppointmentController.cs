using Adapters.Controllers.Common;
using Application.UseCases.Appointments;

namespace Adapters.Controllers;

public interface IAppointmentController
{
    Task<Result> ScheduleAppointment(Guid patientId, ScheduleAppointmentRequest request);
    Task<Result> GetScheduledAppointments(Guid doctorId);
}

public sealed class AppointmentController(
    IScheduleAppointmentUseCase scheduleAppointmentUseCase,
    IGetScheduledAppointmentsUseCase getScheduledAppointmentsUseCase) : BaseController, IAppointmentController
{
    public async Task<Result> ScheduleAppointment(Guid patientId, ScheduleAppointmentRequest request)
    {
        try
        {
            var response = await Execute(() => scheduleAppointmentUseCase.Execute(request));
            return Result.Created(response);
        }
        catch (ControllerException e)
        {
            return e.Result;
        }
    }

    public async Task<Result> GetScheduledAppointments(Guid doctorId)
    {
        try
        {
            var response = await Execute(() => getScheduledAppointmentsUseCase.Execute(doctorId));
            return Result.Success(response);
        }
        catch (ControllerException e)
        {
            return e.Result;
        }
    }
}