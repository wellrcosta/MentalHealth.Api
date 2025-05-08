namespace MentalHealth.Api.Models;

public class Employee
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Team { get; set; }
    public string? Role { get; set; }

    public DateTime AcceptedTermsAt { get; set; }
    public DateTime AcceptedPrivacyAt { get; set; }
    public string AcceptedIp { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Checkin> Checkins { get; set; } = new List<Checkin>();
}