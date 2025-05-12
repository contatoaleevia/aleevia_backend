using Application.Helpers;
using Application.Services;
using Application.Services.Addresses;
using Application.Services.Authentications;
using Application.Services.Managers;
using Application.Services.Offices;
using Application.Services.Faqs;
using Application.Services.Users;
using Application.Services.ServiceTypes;
using Application.Services.OfficeAttendances;
using Microsoft.Extensions.DependencyInjection;
using Application.Services.HealthcareProfessionals;
using Application.Services.IaChats;
using Application.Services.Patients;
using Application.Services.Professionals;
using Application.Services.PasswordResets;

namespace Application.DependencyInjections;

public static class ApplicationIocContainer
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFaqService, FaqService>();
        services.AddScoped<IFaqPageService, FaqPageService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IGenerateJwtTokenHelper, GenerateJwtTokenHelper>();
        services.AddScoped<IManagerService, ManagerService>();
        services.AddScoped<IOfficeService, OfficeService>();
        services.AddScoped<IServiceTypeService, ServiceTypeService>();
        services.AddScoped<IProfessionService, ProfessionService>();
        services.AddScoped<IOfficeAttendanceService, OfficeAttendanceService>();
        services.AddScoped<IIaChatService, IaChatService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IProfessionalService, ProfessionalService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IPatientLeadService, PatientLeadService>();
        services.AddScoped<IPasswordResetService, PasswordResetService>();
    }
}