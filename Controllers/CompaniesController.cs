using Microsoft.AspNetCore.Mvc;
using MentalHealth.Api.DTOs;
using MentalHealth.Api.Models;
using MentalHealth.Api.Services;
using MentalHealth.Api.Services.Interfaces;

namespace MentalHealth.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class CompaniesController(ICompanyService companyService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyDto dto)
    {
        Company company = await companyService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = company.Id }, company);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Company? company = await companyService.GetByIdAsync(id);
        if (company == null) return NotFound();
        return Ok(company);
    }
}
