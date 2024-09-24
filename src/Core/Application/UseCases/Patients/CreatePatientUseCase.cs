using Application.Gateways;
using Application.UseCases.Patients.Validators;
using Entities.Patients.PatientAggregate;

namespace Application.UseCases.Patients;

public interface ICreatePatientUseCase : IUseCase<CreatePatientRequest, CreatePatientResponse>;

public sealed class CreatePatientUseCase(
    IPatientGateway patientGateway) : ICreatePatientUseCase
{
    private readonly CreatePatientValidator _validator = new(patientGateway);
    
    public async Task<CreatePatientResponse> Execute(CreatePatientRequest request)
    {
        try
        {
            await _validator.Validate(request);

            var patient = new Patient(request.Name, request.Cpf, request.Email, request.Password);

            await patientGateway.Save(patient);

            return new CreatePatientResponse(patient.Id, patient.Name, patient.Cpf, patient.Email, patient.CreatedAt);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"Failed to register the doctor. Error: {e.Message}", e);
        }
    }
}

public record CreatePatientRequest(string Name, string Cpf, string Email, string Password);

public record CreatePatientResponse(Guid Id, string Name, string Cpf, string Email, DateTime CreatedAt);