using Entities.SeedWork.Extensions;
using Entities.SeedWork;
using Entities.Users.UserAggregate.Validators;
using Entities.Doctors.DoctorAggregate;
using Entities.Patients.PatientAggregate;

namespace Entities.Users.UserAggregate;

public class User : Entity, IAggregatedRoot
{
    public string Name { get; protected set; }
    public string Cpf { get; protected set; }
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    // Relacionamento com Doctor
    public Doctor? Doctor { get; protected set; }

    // Relacionamento com Patient
    public Patient? Patient { get; protected set; }

    public User(string name, string cpf, string email, string password)
    {
        Id = Guid.NewGuid();
        Name = name;
        Cpf = cpf;
        Email = email;
        Password = password.ToMd5();
        CreatedAt = DateTime.UtcNow;

        if (Validator.IsValid(this, out var error) is false)
            throw new DomainException(error);
    }

    private static readonly IValidator<User> Validator = new UserValidator();

    // Required for EF
    protected User()
    {
    }
}