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
    
    public DbSet<Company> Companies
    {
        get => Set<Company>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .HasIndex(e => e.Email)
            .IsUnique();

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Checkin>()
            .HasOne(c => c.Employee)
            .WithMany(e => e.Checkins)
            .HasForeignKey(c => c.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
