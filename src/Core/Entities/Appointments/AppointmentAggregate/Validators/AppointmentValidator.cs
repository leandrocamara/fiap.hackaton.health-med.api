using Entities.SeedWork;

namespace Entities.Appointments.AppointmentAggregate.Validators;

internal sealed class AppointmentValidator : IValidator<Appointment>
{
    public bool IsValid(Appointment instance, out string error)
    {
        error = string.Empty;
        return true;
    }
}