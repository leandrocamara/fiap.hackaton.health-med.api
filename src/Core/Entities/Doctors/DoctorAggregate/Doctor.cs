using Entities.Doctors.DoctorAggregate.Validators;
using Entities.SeedWork;
using Entities.SeedWork.Extensions;
using Entities.Users.UserAggregate;

namespace Entities.Doctors.DoctorAggregate;

public sealed class Doctor : User, IAggregatedRoot
{
    public string Crm { get; private set; }
    
    public IReadOnlyCollection<Availability> Availabilities => _availabilities.AsReadOnly();
    private readonly IList<Availability> _availabilities;

    public Doctor(string name, string cpf, string crm, string email, string password) : base(name, cpf, email, password)
    {
        Id = Guid.NewGuid();     
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