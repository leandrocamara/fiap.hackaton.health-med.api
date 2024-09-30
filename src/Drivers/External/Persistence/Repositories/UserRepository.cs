using Adapters.Gateways.Auth;
using Entities.Users.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace External.Persistence.Repositories;

public sealed class UserRepository(HealthMedContext context) : BaseRepository<User>(context), IUserRepository
{
    public User? GetByEmail(string email)
    {
        return context.Users
            .Include(u => u.Doctor)
            .Include(u => u.Patient)
            .FirstOrDefault(x => x.Email == email);

    }
}
