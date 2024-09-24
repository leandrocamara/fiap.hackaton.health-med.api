using Application.Gateways;

namespace Application.UseCases.Appointments.Validators;

public sealed class ScheduleAppointmentValidator(IAppointmentGateway appointmentGateway)
{
    public Task Validate(ScheduleAppointmentRequest request)
    {
        // TODO: Implement validations
        return Task.CompletedTask;
    }
}