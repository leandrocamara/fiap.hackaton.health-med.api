using Application.Gateways;
using Entities.SeedWork;

namespace Application.UseCases.Appointments;

public interface IGetScheduledAppointmentsUseCase : IUseCase<Guid, GetScheduledAppointmentsResponse>;

public class GetScheduledAppointmentsUseCase(
    IAppointmentGateway appointmentGateway) : IGetScheduledAppointmentsUseCase
{
    public async Task<GetScheduledAppointmentsResponse> Execute(Guid doctorId)
    {
        try
        {
            var appointments = await appointmentGateway.GetByDoctorId(doctorId);

            return new GetScheduledAppointmentsResponse(appointments.Select(appointment =>
                new ScheduledAppointmentResponse(
                    appointment.Patient.Name,
                    appointment.Availability.DateTime)));
        }
        catch (DomainException e)
        {
            throw new ApplicationException($"Failed to recover the doctor availability. Error: {e.Message}", e);
        }
    }
}

public record GetScheduledAppointmentsResponse(IEnumerable<ScheduledAppointmentResponse> Appointments);

public record ScheduledAppointmentResponse(string Patient, DateTime DateTime);