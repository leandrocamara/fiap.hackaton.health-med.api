using Entities.Appointments.AppointmentAggregate;

namespace Application.Gateways;

public interface IAppointmentGateway
{
    Task<bool> TryLockDoctorAvailability(Appointment appointment);
    Task Save(Appointment appointment);
    Task<IEnumerable<Appointment>> GetByDoctorId(Guid doctorId);
}