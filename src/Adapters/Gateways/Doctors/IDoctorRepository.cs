using Entities.Doctors.DoctorAggregate;

namespace Adapters.Gateways.Doctors;

public interface IDoctorRepository : IRepository<Doctor>
{
    IEnumerable<Doctor> GetAll();
    Availability? GetAvailabilityById(Guid availabilityId);
    Doctor? GetByCpfOrCrm(string cpf, string crm);
}
