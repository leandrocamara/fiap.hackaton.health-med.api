using Application.UseCases.Doctors;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        #region Doctor

        services.AddScoped<ICreateDoctorUseCase, CreateDoctorUseCase>();
        services.AddScoped<IGetDoctorsUseCase, GetDoctorsUseCase>();
        services.AddScoped<ICreateAvailabilityUseCase, CreateAvailabilityUseCase>();
        services.AddScoped<IGetAvailabilityUseCase, GetAvailabilityUseCase>();
        services.AddScoped<IUpdateAvailabilityUseCase, UpdateAvailabilityUseCase>();

        #endregion

        #region Patient

        #endregion

        #region Appointment

        #endregion

        return services;
    }
}