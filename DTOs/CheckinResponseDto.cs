namespace MentalHealth.Api.DTOs;

public class CheckinResponseDto
{
    public Guid Id { get; set; }
    public int Sentiment { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }

    public required string EmployeeName { get; set; }
    public required string EmployeeEmail { get; set; }
}
