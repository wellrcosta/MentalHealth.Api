namespace MentalHealth.Api.DTOs;

public class CreateEmployeeDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Team { get; set; }
    public string? Role { get; set; }
    public Guid CompanyId { get; set; }
    public required DateTime AcceptedTermsAt { get; set; }
    public required DateTime AcceptedPrivacyAt { get; set; }
}
