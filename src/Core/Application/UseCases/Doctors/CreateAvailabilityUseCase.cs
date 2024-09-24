using Application.Gateways;
using Entities.Doctors.DoctorAggregate;

namespace Application.UseCases.Doctors;

public interface ICreateAvailabilityUseCase : IUseCase<CreateAvailabilityRequest, CreateAvailabilityResponse>;

public sealed class CreateAvailabilityUseCase(
    IDoctorGateway doctorGateway) : ICreateAvailabilityUseCase
{
    public async Task<CreateAvailabilityResponse> Execute(CreateAvailabilityRequest request)
    {
        try
        {
            var doctor = await doctorGateway.GetById(request.DoctorId);

            if (doctor is null)
                throw new ApplicationException("Doctor not found.");

            var availability = new Availability(doctor, request.AvailableDateTime);
            doctor.AddAvailability(availability);

            await doctorGateway.Update(doctor);

            return new CreateAvailabilityResponse(doctor.Id, availability.Id, availability.DateTime);
        }
        catch (Exception e)
        {
            throw new ApplicationException(
                $"Failed to register available days and times for appointment scheduling. Error: {e.Message}", e);
        }
    }
}

public class CreateAvailabilityRequest(DateTime availableDateTime)
{
    public Guid DoctorId { get; private set; }
    public DateTime AvailableDateTime { get; init; } = availableDateTime;

    public void SetDoctorId(Guid doctorId) => DoctorId = doctorId;
}

public record CreateAvailabilityResponse(Guid DoctorId, Guid AvailabilityId, DateTime DateTime);