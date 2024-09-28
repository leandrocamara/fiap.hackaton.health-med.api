using Adapters.Gateways.Doctors;
using Entities.Doctors.DoctorAggregate;

namespace External.Persistence.Repositories;

public sealed class DoctorRepository(HealthMedContext context) : BaseRepository<Doctor>(context), IDoctorRepository;
