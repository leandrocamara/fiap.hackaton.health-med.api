using Entities.Appointments.AppointmentAggregate;

namespace Adapters.Gateways.Appointments;

public interface IAppointmentRepository : IRepository<Appointment>;