using Entities.Appointments.AppointmentAggregate;

namespace Application.Gateways;

public interface IAppointmentGateway
{
    Task<bool> TryLockDoctorAvailability(Appointment appointment);
    void Save(Appointment appointment);
    IEnumerable<Appointment> GetByDoctorId(Guid doctorId);
}