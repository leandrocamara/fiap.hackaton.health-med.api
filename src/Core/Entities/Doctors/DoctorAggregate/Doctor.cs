using Entities.Doctors.DoctorAggregate.Validators;
using Entities.SeedWork;
using Entities.SeedWork.Extensions;

namespace Entities.Doctors.DoctorAggregate;

public sealed class Doctor : Entity, IAggregatedRoot
{
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public string Crm { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyCollection<Availability> Availabilities => _availabilities.AsReadOnly();
    private readonly IList<Availability> _availabilities;

    public Doctor(string name, string cpf, string crm, string email, string password)
    {
        Id = Guid.NewGuid();
        Name = name;
        Cpf = cpf;
        Crm = crm;
        Email = email;
        Password = password.ToMd5();
        CreatedAt = DateTime.UtcNow;

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