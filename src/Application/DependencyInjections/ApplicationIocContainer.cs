using Application.Doctors.Contracts;
using Application.Doctors.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjections;

public static class ApplicationIocContainer
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDoctorService, DoctorService>();
    }
}