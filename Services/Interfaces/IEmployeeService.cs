using MentalHealth.Api.DTOs;
using MentalHealth.Api.Models;

namespace MentalHealth.Api.Services.Interfaces;

public interface IEmployeeService
{
    Task<Employee> CreateAsync(CreateEmployeeDto dto, string acceptedIp);
}