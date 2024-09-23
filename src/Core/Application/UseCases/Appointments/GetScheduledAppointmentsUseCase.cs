namespace Application.UseCases.Appointments;

public interface IGetScheduledAppointmentsUseCase : IUseCase<Guid, GetScheduledAppointmentsResponse>;

public class GetScheduledAppointmentsUseCase : IGetScheduledAppointmentsUseCase
{
    public Task<GetScheduledAppointmentsResponse> Execute(Guid doctorId)
    {
        throw new NotImplementedException();
    }
}

public record GetScheduledAppointmentsResponse;