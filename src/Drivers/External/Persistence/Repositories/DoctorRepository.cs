using Adapters.Gateways.Doctors;
using Entities.Doctors.DoctorAggregate;
using Microsoft.EntityFrameworkCore;

namespace External.Persistence.Repositories;

public sealed class DoctorRepository(HealthMedContext context) : BaseRepository<Doctor>(context), IDoctorRepository
{
    public override Doctor? GetById(Guid id) =>
        context.Doctors
            .Include(d => d.Availabilities)
            .FirstOrDefault(d => d.Id.Equals(id));

    public IEnumerable<Doctor> GetAll() => context.Doctors.Include(u => u.User).ToList();

    public Availability? GetAvailabilityById(Guid availabilityId) =>
        context.Doctors
            .Include(d => d.Availabilities)
            .SelectMany(x => x.Availabilities)
            .FirstOrDefault(x => x.Id.Equals(availabilityId));

    public Doctor? GetByCpfOrCrm(string cpf, string crm) =>
        context.Doctors
            .Include(d => d.User)
            .FirstOrDefault(d => d.User.Cpf.Equals(cpf) || d.Crm.Equals(crm));
}