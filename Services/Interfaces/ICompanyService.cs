using MentalHealth.Api.DTOs;
using MentalHealth.Api.Models;

namespace MentalHealth.Api.Services.Interfaces;

public interface ICompanyService
{
    Task<Company> CreateAsync(CreateCompanyDto dto);
    Task<Company?> GetByIdAsync(Guid id);
}
