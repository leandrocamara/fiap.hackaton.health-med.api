using Entities.SeedWork;

namespace Entities.Patients.PatientAggregate.Validators;

internal sealed class PatientValidator : IValidator<Patient>
{
    public bool IsValid(Patient instance, out string error)
    {
        error = string.Empty;
        return true;
    }
}