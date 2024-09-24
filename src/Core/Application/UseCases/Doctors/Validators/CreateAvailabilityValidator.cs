using Application.Gateways;

namespace Application.UseCases.Doctors.Validators;

public sealed class CreateAvailabilityValidator(IDoctorGateway doctorGateway)
{
    public Task Validate(CreateAvailabilityRequest request)
    {
        // TODO: Implement validations
        return Task.CompletedTask;
    }
}