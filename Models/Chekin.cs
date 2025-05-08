namespace MentalHealth.Api.Models;

public class Checkin
{
    public Guid Id { get; set; }
    public Guid EmployeeId { get; set; }
    public int Sentiment { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Employee? Employee { get; set; }
}
