using Adapters.Gateways.Appointments;
using Entities.Appointments.AppointmentAggregate;

namespace External.Persistence.Repositories;

public sealed class AppointmentRepository(HealthMedContext context)
    : BaseRepository<Appointment>(context), IAppointmentRepository;