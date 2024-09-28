using Entities.Doctors.DoctorAggregate;

namespace Adapters.Gateways.Doctors;

public interface IDoctorRepository : IRepository<Doctor>
{
    Task<IEnumerable<Doctor>> GetAllAsync();
};
