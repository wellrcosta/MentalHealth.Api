using MentalHealth.Api.Data;
using MentalHealth.Api.DTOs;
using MentalHealth.Api.Models;
using MentalHealth.Api.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace MentalHealth.Api.Services;

public class EmployeeService(AppDbContext context, ILogger<EmployeeService> logger) : IEmployeeService
{
    public async Task<Employee> CreateAsync(CreateEmployeeDto dto, string acceptedIp)
    {
        if (await context.Employees.AnyAsync(e => e.Email == dto.Email))
        {
            throw new Exception("Employee with this email already exists.");
        }
        bool companyExists = await context.Companies.AnyAsync(c => c.Id == dto.CompanyId);
        if (!companyExists)
            throw new Exception("Company not found.");
        
        Employee employee = new()
        {
            Name = dto.Name,
            Email = dto.Email,
            Team = dto.Team,
            Role = dto.Role,
            AcceptedTermsAt = dto.AcceptedTermsAt,
            AcceptedPrivacyAt = dto.AcceptedPrivacyAt,
            AcceptedIp = acceptedIp,
            CompanyId = dto.CompanyId
        };

        context.Employees.Add(employee);
        await context.SaveChangesAsync();
        
        logger.LogInformation("New employee created: {Email}", employee.Email);

        return employee;
    }
}
