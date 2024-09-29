using Entities.Doctors.DoctorAggregate;

namespace Application.Gateways;

public interface IDoctorGateway
{
    void Save(Doctor doctor);
    Task<Doctor?> GetByCpfOrCrm(string cpf, string crm);
    Task<Doctor?> GetByEmail(string email);
    Task<IEnumerable<Doctor>> GetAll();
    Doctor? GetById(Guid doctorId);
    void Update(Doctor doctor);
    Task<Availability?> GetAvailabilityById(Guid availabilityId);
    Task UpdateAvailability(Availability availability);
}