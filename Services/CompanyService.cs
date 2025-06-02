using MentalHealth.Api.Data;
using MentalHealth.Api.DTOs;
using MentalHealth.Api.Models;
using MentalHealth.Api.Services.Interfaces;

namespace MentalHealth.Api.Services;

public class CompanyService(AppDbContext context) : ICompanyService
{
    public async Task<Company> CreateAsync(CreateCompanyDto dto)
    {
        Company company = new()
        {
            Name = dto.Name
        };

        context.Companies.Add(company);
        await context.SaveChangesAsync();

        return company;
    }

    public async Task<Company?> GetByIdAsync(Guid id)
    {
        return await context.Companies.FindAsync(id);
    }
}
