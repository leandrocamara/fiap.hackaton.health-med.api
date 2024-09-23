namespace Application.UseCases.Doctors;

public interface IGetAvailabilityUseCase : IUseCase<GetAvailabilityResponse>;

public sealed class GetAvailabilityUseCase : IGetAvailabilityUseCase
{
    public Task<GetAvailabilityResponse> Execute()
    {
        throw new NotImplementedException();
    }
}

public record GetAvailabilityResponse;