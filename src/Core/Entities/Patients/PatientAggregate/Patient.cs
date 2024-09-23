using Entities.Patients.PatientAggregate.Validators;
using Entities.SeedWork;

namespace Entities.Patients.PatientAggregate;

public class Patient : Entity, IAggregatedRoot
{
    private static readonly IValidator<Patient> Validator = new PatientValidator();

    // Required for EF
    private Patient()
    {
    }
}