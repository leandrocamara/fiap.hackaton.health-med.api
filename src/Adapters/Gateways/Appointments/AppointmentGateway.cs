using Application.Gateways;
using Entities.Appointments.AppointmentAggregate;

namespace Adapters.Gateways.Appointments;

public class AppointmentGateway(IAppointmentRepository repository) : IAppointmentGateway
{
    public Task<bool> TryLockDoctorAvailability(Appointment appointment)
    {
        // TODO: Lock with Redis
        return Task.FromResult(true);
    }

    public void Save(Appointment appointment) => repository.Add(appointment);

    public IEnumerable<Appointment> GetByDoctorId(Guid doctorId) => repository.GetByDoctorId(doctorId);
}