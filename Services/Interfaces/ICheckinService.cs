using MentalHealth.Api.DTOs;
using MentalHealth.Api.Models;

namespace MentalHealth.Api.Services.Interfaces;

public interface ICheckinService
{
    Task<CheckinResponseDto> CreateAsync(CreateCheckinDto dto);
    Task<List<CheckinResponseDto>> GetLast7DaysByEmployee(Guid employeeId);
}
