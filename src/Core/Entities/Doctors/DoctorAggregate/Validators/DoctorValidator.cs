using Entities.SeedWork;

namespace Entities.Doctors.DoctorAggregate.Validators;

internal sealed class DoctorValidator : IValidator<Doctor>
{
    public bool IsValid(Doctor order, out string error)
    {
        error = string.Empty;
        return true;
    }
}
