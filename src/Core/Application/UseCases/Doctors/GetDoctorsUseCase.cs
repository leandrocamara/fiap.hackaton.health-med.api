namespace Application.UseCases.Doctors;

public interface IGetDoctorsUseCase : IUseCase<GetDoctorsResponse>;

public sealed class GetDoctorsUseCase : IGetDoctorsUseCase
{
    public Task<GetDoctorsResponse> Execute()
    {
        throw new NotImplementedException();
    }
}

public record GetDoctorsResponse;