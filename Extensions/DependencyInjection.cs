using MentalHealth.Api.Services;
using MentalHealth.Api.Services.Interfaces;

namespace MentalHealth.Api.Extensions;

public static class DependencyInjection
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ICheckinService, CheckinService>();
        services.AddScoped<ICompanyService, CompanyService>();
    }
}
