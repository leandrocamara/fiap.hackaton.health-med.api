using Entities.SeedWork;

namespace Entities.Doctors.DoctorAggregate.Validators;

internal sealed class DoctorValidator : IValidator<Doctor>
{
    public bool IsValid(Doctor doctor, out string error)
    {
        error = string.Empty;
        return true;
    }
}
