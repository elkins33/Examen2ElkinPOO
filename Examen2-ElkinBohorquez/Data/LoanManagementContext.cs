using Microsoft.EntityFrameworkCore;
using Examen2_ElkinBohorquez.Models;
using Examen2_ElkinBohorquez.Entities;

public class LoanManagementContext : DbContext
{
    public LoanManagementContext(DbContextOptions<LoanManagementContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<AmortizationDetail> AmortizationDetalis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AmortizationDetail>()
            .HasKey(ad => ad.Id);
    }
}