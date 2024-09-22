using Entities.Doctors.DoctorAggregate.Validators;
using Entities.SeedWork;

namespace Entities.Doctors.DoctorAggregate;

public class Doctor : Entity, IAggregatedRoot
{
    private static readonly IValidator<Doctor> Validator = new DoctorValidator();

    // Required for EF
    private Doctor()
    {
    }
}