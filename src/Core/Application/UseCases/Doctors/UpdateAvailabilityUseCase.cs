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

            var doctor = doctorGateway.GetById(request.GetDoctorId());

            if (doctor is null)
                throw new ApplicationException("Doctor not found.");

            doctor.UpdateAvailability(request.AvailabilityId, request.AvailableDateTime);
            doctorGateway.Update(doctor);

            return new UpdateAvailabilityResponse(doctor.Id, request.AvailabilityId, request.AvailableDateTime);
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