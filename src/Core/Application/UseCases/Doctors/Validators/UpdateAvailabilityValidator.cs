using Application.Gateways;

namespace Application.UseCases.Doctors.Validators;

public sealed class UpdateAvailabilityValidator(IDoctorGateway doctorGateway)
{
    public Task Validate(UpdateAvailabilityRequest request)
    {
        // TODO: Implement validations
        return Task.CompletedTask;
    }
}