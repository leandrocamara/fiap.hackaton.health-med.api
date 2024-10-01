using Entities.Patients.PatientAggregate.Validators;
using Entities.SeedWork;
using Entities.Users.UserAggregate;

namespace Entities.Patients.PatientAggregate;

public sealed class Patient : Entity, IAggregatedRoot
{
    public User User { get; private set; }
    public Guid UserId { get; private set; }

    public Patient(User user)
    {
        Id = Guid.NewGuid();
        User = user;
        UserId = user.Id;

        if (Validator.IsValid(this, out var error) is false)
            throw new DomainException(error);
    }

    private static readonly IValidator<Patient> Validator = new PatientValidator();

    // Required for EF
    private Patient()
    {
    }
}