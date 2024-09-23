namespace Application.UseCases.Patients;

public interface ICreatePatientUseCase : IUseCase<CreatePatientRequest, CreatePatientResponse>;

public sealed class CreatePatientUseCase : ICreatePatientUseCase
{
    public Task<CreatePatientResponse> Execute(CreatePatientRequest request)
    {
        throw new NotImplementedException();
    }
}

public record CreatePatientRequest;

public record CreatePatientResponse;