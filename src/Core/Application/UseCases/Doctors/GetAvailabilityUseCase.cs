using Application.Gateways;
using Entities.SeedWork;

namespace Application.UseCases.Doctors;

public interface IGetAvailabilityUseCase : IUseCase<Guid, GetAvailabilityResponse>;

public sealed class GetAvailabilityUseCase(
    IDoctorGateway doctorGateway) : IGetAvailabilityUseCase
{
    public async Task<GetAvailabilityResponse> Execute(Guid doctorId)
    {
        try
        {
            var doctor = doctorGateway.GetById(doctorId);

            if (doctor is null)
                throw new ApplicationException("Doctor not found.");

            return new GetAvailabilityResponse(doctor.Availabilities
                .Select(availability => new AvailabilityResponse(availability.Id, availability.DateTime)));
        }
        catch (DomainException e)
        {
            throw new ApplicationException($"Failed to recover the doctor availability. Error: {e.Message}", e);
        }
    }
}

public record GetAvailabilityResponse(IEnumerable<AvailabilityResponse> Availabilities);

public record AvailabilityResponse(Guid Id, DateTime DateTime);