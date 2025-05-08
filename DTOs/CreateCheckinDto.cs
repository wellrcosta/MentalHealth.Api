namespace MentalHealth.Api.DTOs;

public class CreateCheckinDto
{
    public required int Sentiment { get; set; }
    public string? Notes { get; set; }
}
