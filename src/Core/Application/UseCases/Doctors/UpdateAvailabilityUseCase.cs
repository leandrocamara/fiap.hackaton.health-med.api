using Application.Gateways;
using Application.UseCases.Doctors.Validators;

namespace Application.UseCases.Doctors;

public interface IUpdateAvailabilityUseCase : IUseCase<UpdateAvailabilityRequest, UpdateAvailabilityResponse>;

public sealed class UpdateAvailabilityUseCase(
    IDoctorGateway doctorGateway) : IUpdateAvailabilityUseCase
{
    private readonly UpdateAvailabilityValidator _validator = new(doctorGateway);

    public async Task<UpdateAvailabilityResponse> Execute(UpdateAvailabilityRequest request)
    {
        try
        {
            await _validator.Validate(request);

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

public class UpdateAvailabilityRequest(Guid availabilityId, DateTime availableDateTime)
{
    public Guid AvailabilityId { get; } = availabilityId;
    public DateTime AvailableDateTime { get; } = availableDateTime;
    private Guid DoctorId { get; set; }

    public void SetDoctorId(Guid doctorId) => DoctorId = doctorId;
    public Guid GetDoctorId() => DoctorId;
}

public record UpdateAvailabilityResponse(Guid DoctorId, Guid AvailabilityId, DateTime DateTime);