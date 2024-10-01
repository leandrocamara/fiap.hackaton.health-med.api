using Application.Gateways;

namespace Application.UseCases.Doctors.Validators;

public sealed class CreateDoctorValidator(IDoctorGateway doctorGateway)
{
    public async Task Validate(CreateDoctorRequest request)
    {
        if (await IsDoctorExists(request.Cpf, request.Crm))
            throw new ApplicationException("The doctor already exists");

        if (await IsEmailAlreadyUsed(request.Email))
            throw new ApplicationException("the email is already used");
    }

    private async Task<bool> IsDoctorExists(string cpf, string crm) =>
        doctorGateway.GetByCpfOrCrm(cpf, crm) is not null;

    private async Task<bool> IsEmailAlreadyUsed(string email) =>
        doctorGateway.GetByEmail(email) is not null;
}