using Application.Gateways;
using Entities.Doctors.DoctorAggregate;

namespace Adapters.Gateways.Doctors;

public class DoctorGateway : IDoctorGateway
{
    public Task Save(Doctor doctor)
    {
        // TODO: Use Repository
        return Task.CompletedTask;
    }

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

    public Task<Doctor?> GetById(Guid doctorId)
    {
        // TODO: Use Repository
        return Task.FromResult<Doctor>(null!)!;
    }

    public Task Update(Doctor doctor)
    {
        // TODO: Use Repository
        return Task.CompletedTask;
    }
}