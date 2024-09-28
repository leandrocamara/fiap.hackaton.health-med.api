using Entities.Users.UserAggregate;

namespace Adapters.Gateways.Auth;

public interface IUserRepository : IRepository<User>
{
    User? GetByEmail(string email);
}
