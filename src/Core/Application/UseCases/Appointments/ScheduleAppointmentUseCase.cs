namespace Application.UseCases.Appointments;

public interface IScheduleAppointmentUseCase : IUseCase<ScheduleAppointmentRequest, ScheduleAppointmentResponse>;

public sealed class ScheduleAppointmentUseCase : IScheduleAppointmentUseCase
{
    public Task<ScheduleAppointmentResponse> Execute(ScheduleAppointmentRequest request)
    {
        throw new NotImplementedException();
    }
}

public record ScheduleAppointmentRequest;

public record ScheduleAppointmentResponse;