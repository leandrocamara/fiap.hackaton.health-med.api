using Entities.Patients.PatientAggregate;
using Entities.Users.UserAggregate;

namespace Application.Gateways;

public interface IPatientGateway
{
    void Save(Patient patient);
    User? GetByCpf(string cpf);
    User? GetByEmail(string email);
    Patient? GetById(Guid patientId);
}