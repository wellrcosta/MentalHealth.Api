using Microsoft.EntityFrameworkCore;
using MentalHealth.Api.Models;

namespace MentalHealth.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees
    {
        get => Set<Employee>();
    }

    public DbSet<Checkin> Checkins
    {
        get => Set<Checkin>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>(e =>
        {
            e.HasIndex(emp => emp.Email).IsUnique();
        });

        modelBuilder.Entity<Checkin>()
            .HasOne(c => c.Employee)
            .WithMany(e => e.Checkins)
            .HasForeignKey(c => c.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
