using Application.Gateways;
using Entities.SeedWork;

namespace Application.UseCases.Doctors;

public interface IGetDoctorsUseCase : IUseCase<IEnumerable<GetDoctorResponse>>;

public sealed class GetDoctorsUseCase(
    IDoctorGateway doctorGateway) : IGetDoctorsUseCase
{
    public async Task<IEnumerable<GetDoctorResponse>> Execute()
    {
        try
        {
            var doctors = doctorGateway.GetAll();

            return doctors.Select(doctor => new GetDoctorResponse(doctor.Id, doctor.User.Name, doctor.Crm));
        }
        catch (DomainException e)
        {
            throw new ApplicationException($"Failed to recover the doctors. Error: {e.Message}", e);
        }
    }
}

public record GetDoctorResponse(Guid Id, string Name, string Crm);