using Entities.Appointments.AppointmentAggregate.Validators;
using Entities.SeedWork;

namespace Entities.Appointments.AppointmentAggregate;

public class Appointment : Entity, IAggregatedRoot
{
    private static readonly IValidator<Appointment> Validator = new AppointmentValidator();

    // Required for EF
    private Appointment()
    {
    }
}