using Adapters.Gateways.Patients;
using Entities.Patients.PatientAggregate;

namespace External.Persistence.Repositories;

public sealed class PatientRepository(HealthMedContext context) : BaseRepository<Patient>(context), IPatientRepository;