using MentalHealth.Api.Data;

using Microsoft.AspNetCore.Mvc;
using MentalHealth.Api.DTOs;
using MentalHealth.Api.Models;
using MentalHealth.Api.Services.Interfaces;

namespace MentalHealth.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class EmployeesController(IEmployeeService employeeService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
    {
        string ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        Employee employee = await employeeService.CreateAsync(dto, ip);
        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromServices] AppDbContext context, Guid id)
    {
        Employee? employee = await context.Employees.FindAsync(id);
        if (employee == null) return NotFound();
        return Ok(employee);
    }
}
