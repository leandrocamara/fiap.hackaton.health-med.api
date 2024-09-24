using Entities.Patients.PatientAggregate;

namespace Application.Gateways;

public interface IPatientGateway
{
    Task Save(Patient patient);
    Task<Patient?> GetByCpf(string cpf);
    Task<Patient?> GetByEmail(string email);
    Task<Patient?> GetById(Guid patientId);
}