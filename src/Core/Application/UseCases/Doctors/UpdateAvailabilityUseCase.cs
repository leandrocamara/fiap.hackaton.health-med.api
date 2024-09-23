namespace Application.UseCases.Doctors;

public interface IUpdateAvailabilityUseCase : IUseCase<UpdateAvailabilityRequest, UpdateAvailabilityResponse>;

public sealed class UpdateAvailabilityUseCase : IUpdateAvailabilityUseCase
{
    public Task<UpdateAvailabilityResponse> Execute(UpdateAvailabilityRequest request)
    {
        throw new NotImplementedException();
    }
}

public record UpdateAvailabilityRequest;

public record UpdateAvailabilityResponse;