using MentalHealth.Api.Services;
using MentalHealth.Api.Services.Interfaces;

namespace MentalHealth.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();

        return services;
    }
}
