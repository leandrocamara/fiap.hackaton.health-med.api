using Application.Gateways;

namespace Application.UseCases.Patients.Validators;

public sealed class CreatePatientValidator(IPatientGateway patientGateway)
{
    public async Task Validate(CreatePatientRequest request)
    {
        if (await IsPatientExists(request.Cpf))
            throw new ApplicationException("The patient already exists");

        if (await IsEmailAlreadyUsed(request.Email))
            throw new ApplicationException("the email is already used");
    }

    private async Task<bool> IsPatientExists(string cpf) =>
        patientGateway.GetByCpf(cpf) is not null;

    private async Task<bool> IsEmailAlreadyUsed(string email) =>
        patientGateway.GetByEmail(email) is not null;
}