namespace Application.UseCases.Doctors;

public interface ICreateAvailabilityUseCase : IUseCase<CreateAvailabilityRequest, CreateAvailabilityResponse>;

public sealed class CreateAvailabilityUseCase : ICreateAvailabilityUseCase
{
    public Task<CreateAvailabilityResponse> Execute(CreateAvailabilityRequest request)
    {
        throw new NotImplementedException();
    }
}

public record CreateAvailabilityRequest;

public record CreateAvailabilityResponse;