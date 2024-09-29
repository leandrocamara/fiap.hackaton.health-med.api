using Entities.Patients.PatientAggregate;

namespace Application.Gateways;

public interface IPatientGateway
{
    void Save(Patient patient);
    Patient? GetByCpf(string cpf);
    Patient? GetByEmail(string email);
    Patient? GetById(Guid patientId);
}