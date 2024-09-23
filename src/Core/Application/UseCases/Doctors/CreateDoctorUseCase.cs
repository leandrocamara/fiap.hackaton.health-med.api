namespace Application.UseCases.Doctors;

public interface ICreateDoctorUseCase : IUseCase<CreateDoctorRequest, CreateDoctorResponse>;

public sealed class CreateDoctorUseCase : ICreateDoctorUseCase
{
    public Task<CreateDoctorResponse> Execute(CreateDoctorRequest request)
    {
        throw new NotImplementedException();
    }
}

public record CreateDoctorRequest;

public record CreateDoctorResponse;