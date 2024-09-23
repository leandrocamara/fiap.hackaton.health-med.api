using Adapters.Controllers.Common;
using Application.UseCases.Patients;

namespace Adapters.Controllers;

public interface IPatientController
{
    Task<Result> CreatePatient(CreatePatientRequest request);
}

public sealed class PatientController(
    ICreatePatientUseCase createPatientUseCase) : BaseController, IPatientController
{
    public async Task<Result> CreatePatient(CreatePatientRequest request)
    {
        try
        {
            var response = await Execute(() => createPatientUseCase.Execute(request));
            return Result.Created(response);
        }
        catch (ControllerException e)
        {
            return e.Result;
        }
    }
}