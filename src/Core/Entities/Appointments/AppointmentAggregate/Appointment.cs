using Entities.Appointments.AppointmentAggregate.Validators;
using Entities.Doctors.DoctorAggregate;
using Entities.Patients.PatientAggregate;
using Entities.SeedWork;

namespace Entities.Appointments.AppointmentAggregate;

public class Appointment : Entity, IAggregatedRoot
{
    public Availability Availability { get; private set; }
    public Guid AvailabilityId { get; private set; }
    public Patient Patient { get; private set; }
    public Guid PatientId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Appointment(Patient patient, Availability availability)
    {
        Availability = availability;
        AvailabilityId = availability.Id;
        Patient = patient;
        PatientId = patient.Id;
        CreatedAt = DateTime.UtcNow;
    }

    private static readonly IValidator<Appointment> Validator = new AppointmentValidator();

    // Required for EF
    private Appointment()
    {
    }
}