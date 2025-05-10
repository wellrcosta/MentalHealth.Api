using AutoMapper;

using MentalHealth.Api.Data;
using MentalHealth.Api.DTOs;
using MentalHealth.Api.Models;
using MentalHealth.Api.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace MentalHealth.Api.Services;

public class CheckinService(AppDbContext context, ILogger<CheckinService> logger, IMapper mapper) : ICheckinService
{
    private readonly ILogger<CheckinService> _logger = logger;

    public async Task<CheckinResponseDto> CreateAsync(CreateCheckinDto dto)
    {
        bool exists = await context.Employees.AnyAsync(e => e.Id == dto.EmployeeId);
        if (!exists)
            throw new Exception("Employee not found");

        Checkin checkin = new Checkin
        {
            EmployeeId = dto.EmployeeId,
            Sentiment = dto.Sentiment,
            Notes = dto.Notes
        };

        context.Checkins.Add(checkin);
        await context.SaveChangesAsync();

        await context.Entry(checkin).Reference(c => c.Employee).LoadAsync();

        return mapper.Map<CheckinResponseDto>(checkin);
    }

    public async Task<List<CheckinResponseDto>> GetLast7DaysByEmployee(Guid employeeId)
    {
        List<Checkin> checkins = await context.Checkins
            .Include(c => c.Employee)
            .Where(c => c.EmployeeId == employeeId && c.CreatedAt >= DateTime.UtcNow.AddDays(-7))
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();

        return mapper.Map<List<CheckinResponseDto>>(checkins);
    }
}
