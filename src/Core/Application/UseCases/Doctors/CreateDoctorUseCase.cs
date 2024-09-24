using Application.Gateways;
using Application.UseCases.Doctors.Validators;
using Entities.Doctors.DoctorAggregate;

namespace Application.UseCases.Doctors;

public interface ICreateDoctorUseCase : IUseCase<CreateDoctorRequest, CreateDoctorResponse>;

public sealed class CreateDoctorUseCase(
    IDoctorGateway doctorGateway) : ICreateDoctorUseCase
{
    private readonly CreateDoctorValidator _validator = new(doctorGateway);

    public async Task<CreateDoctorResponse> Execute(CreateDoctorRequest request)
    {
        try
        {
            await _validator.Validate(request);

            var doctor = new Doctor(request.Name, request.Cpf, request.Crm, request.Email, request.Password);

            await doctorGateway.Save(doctor);

            return new CreateDoctorResponse(doctor.Id, doctor.Name, doctor.Cpf, doctor.Crm, doctor.Email, doctor.CreatedAt);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Failed to register the doctor. Error: {e.Message}", e);
        }
    }
}

public record CreateDoctorRequest(string Name, string Cpf, string Crm, string Email, string Password);

public record CreateDoctorResponse(Guid Id, string Name, string Cpf, string Crm, string Email, DateTime CreatedAt);