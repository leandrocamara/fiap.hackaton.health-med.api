using Adapters.Gateways.Auth;
using Application.Gateways;
using Entities.Patients.PatientAggregate;
using Entities.Users.UserAggregate;

namespace Adapters.Gateways.Patients;

public class PatientGateway(
    IPatientRepository patientRepository,
    IUserRepository userRepository) : IPatientGateway
{
    public void Save(Patient patient) => patientRepository.Add(patient);

    public User? GetByCpf(string cpf) => userRepository.GetByCpf(cpf);

    public User? GetByEmail(string email) => userRepository.GetByEmail(email);

    public Patient? GetById(Guid patientId) => patientRepository.GetById(patientId);
}