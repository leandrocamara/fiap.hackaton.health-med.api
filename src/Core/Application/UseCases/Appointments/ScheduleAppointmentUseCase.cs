using Application.Gateways;
using Application.UseCases.Appointments.Validators;
using Entities.Appointments.AppointmentAggregate;
using Entities.Doctors.DoctorAggregate;
using Entities.Patients.PatientAggregate;

namespace Application.UseCases.Appointments;

public interface IScheduleAppointmentUseCase : IUseCase<ScheduleAppointmentRequest, ScheduleAppointmentResponse>;

public sealed class ScheduleAppointmentUseCase(
    IAppointmentGateway appointmentGateway,
    IPatientGateway patientGateway,
    IDoctorGateway doctorGateway) : IScheduleAppointmentUseCase
{
    private readonly ScheduleAppointmentValidator _validator = new(appointmentGateway);

    public async Task<ScheduleAppointmentResponse> Execute(ScheduleAppointmentRequest request)
    {
        try
        {
            await _validator.Validate(request);

            var patient = await GetPatient(request.GetPatientId());
            var availability = await GetAvailability(request.AvailabilityId);
            var appointment = new Appointment(patient, availability);

            if (await appointmentGateway.TryLockDoctorAvailability(appointment) is false)
                throw new ApplicationException("The doctor's availability is already lock.");

            appointmentGateway.Save(appointment);

            return new ScheduleAppointmentResponse(
                appointment.Id,
                appointment.Availability.DateTime,
                appointment.CreatedAt);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Failed to register appointment schedule. Error: {e.Message}", e);
        }
    }

    private async Task<Patient> GetPatient(Guid patientId)
    {
        var patient = patientGateway.GetById(patientId);

        if (patient is null)
            throw new ApplicationException("Patient not found.");

        return patient;
    }

    private async Task<Availability> GetAvailability(Guid availabilityId)
    {
        var availability = doctorGateway.GetAvailabilityById(availabilityId);

        if (availability is null)
            throw new ApplicationException("Doctor availability not found.");

        return availability;
    }
}

public class ScheduleAppointmentRequest(Guid availabilityId)
{
    public Guid AvailabilityId { get; } = availabilityId;
    private Guid PatientId { get; set; }

    public void SetPatientId(Guid patientId) => PatientId = patientId;
    public Guid GetPatientId() => PatientId;
}

public record ScheduleAppointmentResponse(Guid AppointmentId, DateTime AppointmentDateTime, DateTime CreatedAt);