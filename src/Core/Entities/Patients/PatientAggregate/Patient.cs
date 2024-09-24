using Entities.Patients.PatientAggregate.Validators;
using Entities.SeedWork;
using Entities.SeedWork.Extensions;

namespace Entities.Patients.PatientAggregate;

public sealed class Patient : Entity, IAggregatedRoot
{
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Patient(string name, string cpf, string email, string password)
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

    private static readonly IValidator<Patient> Validator = new PatientValidator();

    // Required for EF
    private Patient()
    {
    }
}