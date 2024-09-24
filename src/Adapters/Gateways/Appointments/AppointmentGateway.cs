using Application.Gateways;
using Entities.Appointments.AppointmentAggregate;

namespace Adapters.Gateways.Appointments;

public class AppointmentGateway : IAppointmentGateway
{
    public Task Save(Appointment appointment)
    {
        // TODO: Use Repository
        return Task.CompletedTask;
    }
}