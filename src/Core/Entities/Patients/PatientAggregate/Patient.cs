using Entities.Patients.PatientAggregate.Validators;
using Entities.SeedWork;
using Entities.SeedWork.Extensions;
using Entities.Users.UserAggregate;

namespace Entities.Patients.PatientAggregate;

public sealed class Patient : User, IAggregatedRoot
{
    public Patient(string name, string cpf, string email, string password) : base(name, cpf, email, password)
    {
        Id = Guid.NewGuid();
    

        if (Validator.IsValid(this, out var error) is false)
            throw new DomainException(error);
    }

    private static readonly IValidator<Patient> Validator = new PatientValidator();

    // Required for EF
    private Patient()
    {
    }
}