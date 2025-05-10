using Microsoft.AspNetCore.Mvc;
using MentalHealth.Api.DTOs;
using MentalHealth.Api.Models;
using MentalHealth.Api.Services.Interfaces;

namespace MentalHealth.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class CheckinsController(ICheckinService checkinService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCheckin([FromBody] CreateCheckinDto dto)
    {
        CheckinResponseDto checkin = await checkinService.CreateAsync(dto);
        return Created(string.Empty, checkin);
    }

    [HttpGet("last7days/{employeeId:guid}")]
    public async Task<ActionResult<List<CheckinResponseDto>>> GetLast7Days(Guid employeeId)
    {
        List<CheckinResponseDto> result = await checkinService.GetLast7DaysByEmployee(employeeId);
        return Ok(result);
    }
}
