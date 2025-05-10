namespace MentalHealth.Api.DTOs;

public class CreateCheckinDto
{
    public required Guid EmployeeId { get; set; }
    public required int Sentiment { get; set; }
    public string? Notes { get; set; }
}
