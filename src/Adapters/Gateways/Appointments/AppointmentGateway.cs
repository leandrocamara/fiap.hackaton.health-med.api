using Application.Gateways;
using Entities.Appointments.AppointmentAggregate;

namespace Adapters.Gateways.Appointments;

public class AppointmentGateway : IAppointmentGateway
{
    public Task<bool> TryLockDoctorAvailability(Appointment appointment)
    {
        // TODO: Lock with Redis
        return Task.FromResult(true);
    }

    public Task Save(Appointment appointment)
    {
        // TODO: Use Repository
        return Task.CompletedTask;
    }
}