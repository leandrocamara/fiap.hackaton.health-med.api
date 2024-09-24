using Application.Gateways;

namespace Application.UseCases.Doctors;

public interface IUpdateAvailabilityUseCase : IUseCase<UpdateAvailabilityRequest, UpdateAvailabilityResponse>;

public sealed class UpdateAvailabilityUseCase(
    IDoctorGateway doctorGateway) : IUpdateAvailabilityUseCase
{
    public async Task<UpdateAvailabilityResponse> Execute(UpdateAvailabilityRequest request)
    {
        try
        {
            var availability = await doctorGateway.GetAvailabilityById(request.AvailabilityId);

            if (availability is null)
                throw new ApplicationException("Availability not found.");

            availability.UpdateDateTime(request.AvailableDateTime);
            await doctorGateway.UpdateAvailability(availability);

            return new UpdateAvailabilityResponse(availability.DoctorId, availability.Id, availability.DateTime);
        }
        catch (Exception e)
        {
            throw new ApplicationException(
                $"Failed to update doctor availability. Error: {e.Message}", e);
        }
    }
}

public class UpdateAvailabilityRequest(DateTime availableDateTime)
{
    public Guid DoctorId { get; private set; }
    public Guid AvailabilityId { get; private set; }
    public DateTime AvailableDateTime { get; init; } = availableDateTime;

    public void SetDoctorId(Guid doctorId) => DoctorId = doctorId;
}

public record UpdateAvailabilityResponse(Guid DoctorId, Guid AvailabilityId, DateTime DateTime);