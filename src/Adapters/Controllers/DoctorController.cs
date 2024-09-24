using Adapters.Controllers.Common;
using Application.UseCases.Doctors;

namespace Adapters.Controllers;

public interface IDoctorController
{
    Task<Result> CreateDoctor(CreateDoctorRequest request);
    Task<Result> GetDoctors();
    Task<Result> CreateAvailability(CreateAvailabilityRequest request);
    Task<Result> GetAvailability(Guid doctorId);
    Task<Result> UpdateAvailability(UpdateAvailabilityRequest request);
}

public sealed class DoctorController(
    ICreateDoctorUseCase createDoctorUseCase,
    IGetDoctorsUseCase getDoctorsUseCase,
    ICreateAvailabilityUseCase createAvailabilityUseCase,
    IGetAvailabilityUseCase getAvailabilityUseCase,
    IUpdateAvailabilityUseCase updateAvailabilityUseCase) : BaseController, IDoctorController
{
    public async Task<Result> CreateDoctor(CreateDoctorRequest request)
    {
        try
        {
            var response = await Execute(() => createDoctorUseCase.Execute(request));
            return Result.Created(response);
        }
        catch (ControllerException e)
        {
            return e.Result;
        }
    }

    public async Task<Result> GetDoctors()
    {
        try
        {
            var response = await Execute(getDoctorsUseCase.Execute);
            return Result.Success(response);
        }
        catch (ControllerException e)
        {
            return e.Result;
        }
    }

    public async Task<Result> CreateAvailability(CreateAvailabilityRequest request)
    {
        try
        {
            var response = await Execute(() => createAvailabilityUseCase.Execute(request));
            return Result.Created(response);
        }
        catch (ControllerException e)
        {
            return e.Result;
        }
    }

    public async Task<Result> GetAvailability(Guid doctorId)
    {
        try
        {
            var response = await Execute(() => getAvailabilityUseCase.Execute(doctorId));
            return Result.Success(response);
        }
        catch (ControllerException e)
        {
            return e.Result;
        }
    }

    public async Task<Result> UpdateAvailability(UpdateAvailabilityRequest request)
    {
        try
        {
            var response = await Execute(() => updateAvailabilityUseCase.Execute(request));
            return Result.Success(response);
        }
        catch (ControllerException e)
        {
            return e.Result;
        }
    }
}