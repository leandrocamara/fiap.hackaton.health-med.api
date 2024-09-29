using Application.Gateways;
using Entities.Doctors.DoctorAggregate;

namespace Adapters.Gateways.Doctors;

public class DoctorGateway(
    IDoctorRepository doctorRepository) : IDoctorGateway
{
    public void Save(Doctor doctor) => doctorRepository.Add(doctor);

    public Task<Doctor?> GetByCpfOrCrm(string cpf, string crm)
    {
        // TODO: Use Repository
        return Task.FromResult<Doctor>(null!)!;
    }

    public Task<Doctor?> GetByEmail(string email)
    {
        // TODO: Use Repository
        return Task.FromResult<Doctor>(null!)!;
    }

    public Task<IEnumerable<Doctor>> GetAll()
    {
        // TODO: Use Repository
        return Task.FromResult(Enumerable.Empty<Doctor>());
    }

    public Doctor? GetById(Guid doctorId) => doctorRepository.GetById(doctorId);

    public void Update(Doctor doctor) => doctorRepository.Update(doctor);

    public Task<Availability?> GetAvailabilityById(Guid availabilityId)
    {
        // TODO: Use Repository
        return Task.FromResult<Availability>(null!)!;
    }

    public Task UpdateAvailability(Availability availability)
    {
        // TODO: Use Repository
        return Task.CompletedTask;
    }
}