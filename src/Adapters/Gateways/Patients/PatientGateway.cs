using Application.Gateways;
using Entities.Patients.PatientAggregate;

namespace Adapters.Gateways.Patients;

public class PatientGateway : IPatientGateway
{
    public Task Save(Patient patient)
    {
        // TODO: Use Repository
        return Task.CompletedTask;
    }

    public Task<Patient?> GetByCpf(string cpf)
    {
        // TODO: Use Repository
        return Task.FromResult<Patient>(null!)!;
    }

    public Task<Patient?> GetByEmail(string email)
    {
        // TODO: Use Repository
        return Task.FromResult<Patient>(null!)!;
    }
}