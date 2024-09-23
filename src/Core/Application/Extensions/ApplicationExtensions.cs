using Application.UseCases.Appointments;
using Application.UseCases.Auth;
using Application.UseCases.Doctors;
using Application.UseCases.Patients;
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

        services.AddScoped<ICreatePatientUseCase, CreatePatientUseCase>();

        #endregion

        #region Appointment

        services.AddScoped<IScheduleAppointmentUseCase, ScheduleAppointmentUseCase>();
        services.AddScoped<IGetScheduledAppointmentsUseCase, GetScheduledAppointmentsUseCase>();

        #endregion

        #region Auth

        services.AddScoped<ISignInUseCase, SignInUseCase>();

        #endregion

        return services;
    }
}