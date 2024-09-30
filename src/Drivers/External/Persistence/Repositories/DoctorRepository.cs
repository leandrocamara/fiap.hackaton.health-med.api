using Adapters.Gateways.Doctors;
using Entities.Doctors.DoctorAggregate;
using Microsoft.EntityFrameworkCore;

namespace External.Persistence.Repositories;

public sealed class DoctorRepository(HealthMedContext context) : BaseRepository<Doctor>(context), IDoctorRepository
{
    public IEnumerable<Doctor> GetAll()
    {
        return context.Doctors.Include(u => u.User).ToList();
    }
}
