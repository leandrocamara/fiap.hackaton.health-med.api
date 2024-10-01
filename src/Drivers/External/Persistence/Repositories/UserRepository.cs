using Adapters.Gateways.Auth;
using Entities.Users.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace External.Persistence.Repositories;

public sealed class UserRepository(HealthMedContext context) : BaseRepository<User>(context), IUserRepository
{
    public User? GetByEmail(string email) =>
        context.Users
            .Include(u => u.Doctor)
            .Include(u => u.Patient)
            .FirstOrDefault(x => x.Email == email);

    public User? GetByCpf(string cpf) => context.Users.FirstOrDefault(x => x.Cpf == cpf);
}