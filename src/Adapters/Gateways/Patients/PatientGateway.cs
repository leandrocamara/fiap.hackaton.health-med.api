using Application.Gateways;
using Entities.Patients.PatientAggregate;

namespace Adapters.Gateways.Patients;

public class PatientGateway(
    IPatientRepository patientRepository) : IPatientGateway
{
    public void Save(Patient patient) => patientRepository.Add(patient);

    public Patient? GetByCpf(string cpf)
    {
        // TODO: Use Repository
        return null;
    }

    public Patient? GetByEmail(string email)
    {
        // TODO: Use Repository
        return null;
    }

    public Patient? GetById(Guid patientId) => patientRepository.GetById(patientId);
}