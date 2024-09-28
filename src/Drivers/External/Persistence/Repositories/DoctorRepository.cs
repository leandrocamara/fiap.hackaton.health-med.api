using Adapters.Gateways.Doctors;
using Entities.Doctors.DoctorAggregate;
using Microsoft.EntityFrameworkCore;

namespace External.Persistence.Repositories;

public sealed class DoctorRepository(HealthMedContext context) : BaseRepository<Doctor>(context), IDoctorRepository
{
    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
}
