namespace MentalHealth.Api.Models;

public class Company
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
