using Adapters.Gateways.Auth;
using Application.Gateways;
using Entities.Doctors.DoctorAggregate;
using Entities.Users.UserAggregate;

namespace Adapters.Gateways.Doctors;

public class DoctorGateway(
    IDoctorRepository doctorRepository,
    IUserRepository userRepository) : IDoctorGateway
{
    public void Save(Doctor doctor) => doctorRepository.Add(doctor);

    public Doctor? GetByCpfOrCrm(string cpf, string crm) => doctorRepository.GetByCpfOrCrm(cpf, crm);

    public User? GetByEmail(string email) => userRepository.GetByEmail(email);

    public IEnumerable<Doctor> GetAll() => doctorRepository.GetAll();

    public Doctor? GetById(Guid doctorId) => doctorRepository.GetById(doctorId);

    public void Update(Doctor doctor) => doctorRepository.Update(doctor);

    public Availability? GetAvailabilityById(Guid availabilityId) =>
        doctorRepository.GetAvailabilityById(availabilityId);
}