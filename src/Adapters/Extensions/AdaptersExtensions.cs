using Adapters.Controllers;
using Adapters.Gateways.Appointments;
using Adapters.Gateways.Auth;
using Adapters.Gateways.Doctors;
using Adapters.Gateways.Patients;
using Application.Gateways;
using Microsoft.Extensions.DependencyInjection;

namespace Adapters.Extensions;

public static class AdaptersExtensions
{
    public static IServiceCollection AddAdaptersDependencies(this IServiceCollection services)
    {
        #region Controllers

        services.AddScoped<IAuthController, AuthController>();
        services.AddScoped<IAppointmentController, AppointmentController>();
        services.AddScoped<IDoctorController, DoctorController>();
        services.AddScoped<IPatientController, PatientController>();

        #endregion

        #region Gateways
        
        services.AddScoped<IAuthGateway, AuthGateway>();
        services.AddScoped<IDoctorGateway, DoctorGateway>();
        services.AddScoped<IPatientGateway, PatientGateway>();
        services.AddScoped<IAppointmentGateway, AppointmentGateway>();

        #endregion

        return services;
    }
}