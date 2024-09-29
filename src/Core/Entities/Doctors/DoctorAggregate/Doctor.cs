using Entities.Doctors.DoctorAggregate.Validators;
using Entities.SeedWork;
using Entities.Users.UserAggregate;

namespace Entities.Doctors.DoctorAggregate;

public sealed class Doctor : Entity, IAggregatedRoot
{
    public User User { get; private set; }
    public Guid UserId { get; private set; }
    public string Crm { get; private set; }

    public IReadOnlyCollection<Availability> Availabilities => _availabilities.AsReadOnly();
    private readonly IList<Availability> _availabilities;

    public Doctor(User user, string crm)
    {
        Id = Guid.NewGuid();
        User = user;
        UserId = user.Id;
        Crm = crm;

        _availabilities = new List<Availability>();

        if (Validator.IsValid(this, out var error) is false)
            throw new DomainException(error);
    }

    public void AddAvailability(Availability availability)
    {
        _availabilities.Add(availability);
    }

    private static readonly IValidator<Doctor> Validator = new DoctorValidator();

    // Required for EF
    private Doctor()
    {
    }
}