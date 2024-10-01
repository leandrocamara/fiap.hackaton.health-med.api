using Adapters.Gateways.Appointments;
using Entities.Appointments.AppointmentAggregate;
using Microsoft.EntityFrameworkCore;

namespace External.Persistence.Repositories;

public sealed class AppointmentRepository(HealthMedContext context)
    : BaseRepository<Appointment>(context), IAppointmentRepository
{
    public IEnumerable<Appointment> GetByDoctorId(Guid doctorId) =>
        context.Appointments
            .Include(a => a.Availability)
            .Include(a => a.Patient)
            .ThenInclude(p => p.User)
            .Where(a => a.Availability.DoctorId.Equals(doctorId));
}