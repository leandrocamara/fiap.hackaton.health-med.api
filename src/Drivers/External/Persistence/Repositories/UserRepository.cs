using Adapters.Gateways.Auth;
using Entities.Users.UserAggregate;

namespace External.Persistence.Repositories;

public sealed class UserRepository(HealthMedContext context) : BaseRepository<User>(context), IUserRepository
{
    public User? GetByEmail(string email)
    {
        return context.Users.FirstOrDefault(x => x.Email == email);
    }
}
