using Entities.Doctors.DoctorAggregate;
using Entities.Users.UserAggregate;

namespace Application.Gateways;

public interface IDoctorGateway
{
    void Save(Doctor doctor);
    Doctor? GetByCpfOrCrm(string cpf, string crm);
    User? GetByEmail(string email);
    IEnumerable<Doctor> GetAll();
    Doctor? GetById(Guid doctorId);
    void Update(Doctor doctor);
    Availability? GetAvailabilityById(Guid availabilityId);
}