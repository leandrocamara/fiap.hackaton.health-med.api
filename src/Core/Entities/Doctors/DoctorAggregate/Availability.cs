using Entities.SeedWork;

namespace Entities.Doctors.DoctorAggregate;

public class Availability : Entity
{
    public Doctor Doctor { get; private set; }
    public Guid DoctorId { get; private set; }
    public DateTime DateTime { get; private set; }

    public Availability(Doctor doctor, DateTime dateTime)
    {
        Doctor = doctor;
        DoctorId = doctor.Id;
        DateTime = dateTime;
    }

    // Required for EF
    private Availability()
    {
    }
}