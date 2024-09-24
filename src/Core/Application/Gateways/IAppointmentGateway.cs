using Entities.Appointments.AppointmentAggregate;

namespace Application.Gateways;

public interface IAppointmentGateway
{
    Task Save(Appointment appointment);
}