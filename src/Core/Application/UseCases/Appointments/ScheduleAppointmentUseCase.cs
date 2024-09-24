using Application.Gateways;
using Application.UseCases.Appointments.Validators;
using Entities.Appointments.AppointmentAggregate;

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

            // TODO: Is the doctor's schedule available? (scheduling competition)

            var patient = await patientGateway.GetById(request.GetPatientId());

            if (patient is null)
                throw new ApplicationException("Patient not found.");

            var availability = await doctorGateway.GetAvailabilityById(request.AvailabilityId);

            if (availability is null)
                throw new ApplicationException("Doctor availability not found.");

            var appointment = new Appointment(patient, availability);
            await appointmentGateway.Save(appointment);

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
}

public class ScheduleAppointmentRequest(Guid availabilityId)
{
    public Guid AvailabilityId { get; } = availabilityId;
    private Guid PatientId { get; set; }

    public void SetPatientId(Guid patientId) => PatientId = patientId;
    public Guid GetPatientId() => PatientId;
}

public record ScheduleAppointmentResponse(Guid AppointmentId, DateTime AppointmentDateTime, DateTime CreatedAt);